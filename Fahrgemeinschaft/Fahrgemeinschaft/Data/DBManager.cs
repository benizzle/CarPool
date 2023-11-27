using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Fahrgemeinschaft.Business;
using Fahrgemeinschaft.Data;
using Fahrgemeinschaft.Data.Interfaces;
using Fahrgemeinschaft.Data.Models;

namespace Fahrgemeinschaft
{
	public class DBManager : IServiceManager, IDataLayer
    {
        public string ConnectionString { get; set; }

        public DBManager(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		// Entities
		private List<PersonEntity> GetPersonEntities()		//Personenliste von DB abrufen
		{
			List<PersonEntity> PersonEntities = new List<PersonEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = "SELECT * FROM [Carpool].[dbo].[Person]";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();


				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonEntities.Add(new PersonEntity(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));
				}


				// Call Close when done reading.
				reader.Close();
			}
			return PersonEntities;
		}
		private PersonEntity GetPersonEntityByUsername(string username)
		{

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Person] WHERE Username={username}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					return new PersonEntity(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
				}

				// Call Close when done reading.
				reader.Close();
			}
			throw new Exception("No User found!");
		}
		private CarEntity GetCarEntityById(int carId)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Car] WHERE CarId={carId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					return new CarEntity(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3]));
				}

				// Call Close when done reading.
				reader.Close();
			}
			throw new Exception("No Car found!");
		}
		private List<CarEntity> GetCarEntitiesByUsername(string username)
		{
			List<CarEntity> CarEntities = new List<CarEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Car] WHERE CarId={username}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					CarEntities.Add(new CarEntity(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return CarEntities;
		}
		private List<CarpoolEntity> GetCarpoolEntities()
		{
			List<CarpoolEntity> CarpoolEntities = new List<CarpoolEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = "SELECT * FROM [Carpool].[dbo].[Carpool]";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					CarpoolEntities.Add(new CarpoolEntity(Convert.ToInt32(reader[0]), reader[1].ToString()));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return CarpoolEntities;
		}
		private CarpoolEntity GetCarpoolEntityById(int carpoolId)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Carpool] WHERE CarpoolID={carpoolId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					return new CarpoolEntity(Convert.ToInt32(reader[0]), reader[1].ToString());
				}

				// Call Close when done reading.
				reader.Close();
			}
			throw new Exception("No Carpool found!");
		}
		private List<DriveEntity> GetDriveEntities()
		{
			List<DriveEntity> DriveEntities = new List<DriveEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = "SELECT * FROM [Carpool].[dbo].[Drive]";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					DriveEntities.Add(new DriveEntity(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToDateTime(reader[3]), Convert.ToDateTime(reader[4]), Convert.ToDouble(reader[5]), Convert.ToInt32(reader[6]), reader[7].ToString(), Convert.ToInt32(reader[8])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return DriveEntities;
		}
		private DriveEntity GetDriveEntityById(int driveId)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Drive] WHERE DriveID={driveId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					return new DriveEntity(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToDateTime(reader[3]), Convert.ToDateTime(reader[4]), Convert.ToDouble(reader[5]), Convert.ToInt32(reader[6]), reader[7].ToString(), Convert.ToInt32(reader[8]));
				}

				// Call Close when done reading.
				reader.Close();
			}
			throw new Exception("No Drive found!");
		}
		private List<PersonInDriveEntity> GetPersonInDriveEntities()	//alle personen mit allen drives
		{
			List<PersonInDriveEntity> PersonInDriveEntities = new List<PersonInDriveEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = "SELECT * FROM [Carpool].[dbo].[PersonInDrive]";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonInDriveEntities.Add(new PersonInDriveEntity(reader[0].ToString(), Convert.ToInt32(reader[1]), Convert.ToBoolean(reader[2])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return PersonInDriveEntities;
		}
		private List<PersonInDriveEntity> GetPersonInDriveEntityByDriveId(int driveId) //alle personen von einem drive
		{
			List<PersonInDriveEntity> PersonsByDriveId = new List<PersonInDriveEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Drive] WHERE DriveID={driveId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonsByDriveId.Add(new PersonInDriveEntity(reader[0].ToString(), Convert.ToInt32(reader[1]), Convert.ToBoolean(reader[2])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return PersonsByDriveId;
		}
		private List<PersonInDriveEntity> GetPersonInDriveEntityByUsername(string username) //alle drives von einer person
		{
			List<PersonInDriveEntity> DrivesByUsername = new List<PersonInDriveEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Drive] WHERE Username={username}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					DrivesByUsername.Add(new PersonInDriveEntity(reader[0].ToString(), Convert.ToInt32(reader[1]), Convert.ToBoolean(reader[2])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return DrivesByUsername;
		}
		private List<PersonsCarpoolEntity> GetPersonsCarpoolEntities()
		{
			List<PersonsCarpoolEntity> PersonsCarpoolEntities = new List<PersonsCarpoolEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = "SELECT * FROM [Carpool].[dbo].[PersonsCarpool]";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonsCarpoolEntities.Add(new PersonsCarpoolEntity(reader[0].ToString(), Convert.ToInt32(reader[1])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return PersonsCarpoolEntities;
		}
		private List<PersonsCarpoolEntity> GetPersonsCarpoolEntitiesByCarpoolId(int carpoolId) //alle personen von einem carpool
		{
			List<PersonsCarpoolEntity> PersonsByCarpoolId = new List<PersonsCarpoolEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Drive] WHERE DriveID={carpoolId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonsByCarpoolId.Add(new PersonsCarpoolEntity(reader[0].ToString(), Convert.ToInt32(reader[1])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return PersonsByCarpoolId;
		}
		private List<PersonsCarpoolEntity> GetPersonsCarpoolEntitiesByUsername(string username) //alle carpools von einer person
		{
			List<PersonsCarpoolEntity> CarpoolsByUsername = new List<PersonsCarpoolEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $"SELECT * FROM [Carpool].[dbo].[Drive] WHERE Username={username}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					CarpoolsByUsername.Add(new PersonsCarpoolEntity(reader[0].ToString(), Convert.ToInt32(reader[1])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return CarpoolsByUsername;
		}


		// Entities "umwandeln"
		public List<Person> GetPersons() //PersonEntity in Person "umwandeln"
		{
			List<Person> Persons = new List<Person>();
			List<PersonEntity> personEntities = this.GetPersonEntities();

			foreach (PersonEntity personEntity in personEntities)
			{
				Persons.Add(new Person(personEntity.Username, personEntity.Name, personEntity.Surname, personEntity.Address, personEntity.Gender));
			}
			return Persons;
		}
		public Person GetPersonByUsername(string username)
		{
			PersonEntity personEntity = GetPersonEntityByUsername(username);
			return new Person(personEntity.Username, personEntity.Name, personEntity?.Surname, personEntity.Address, personEntity.Gender);
		}

		public List<Car> GetCarsByUsername(string username)		//mit absicht bei fuelConsumption null einetragen zum "testen"
		{
			List<Car> cars = new List<Car>();
			List<CarEntity> carEntities = this.GetCarEntitiesByUsername(username);

			foreach (CarEntity carEntity in carEntities)
			{
				cars.Add(new Car(carEntity.Description, carEntity.SeatNumber, null));
			}
			return cars;
		}
		public Car GetCarById(int carId)		//carId sollte auch in Car klasse ???
		{
			CarEntity carEntity = GetCarEntityById(carId);
			return new Car(carEntity.Description, carEntity.SeatNumber, null);
		}
		public Carpool GetCarpools(string username)
		{
			List<Carpool> Carpools = new List<Carpool>();
			List<CarpoolEntity> carpoolEntities = this.GetCarpoolEntities();

			foreach (CarpoolEntity carpoolEntity in carpoolEntities)
			{
				Carpools.Add(new Carpool(
			}
		}
		public Carpool GetCarpoolsByUsername(string username)
		{
			
		}
		public Carpool GetCarpoolsByUsername(string username)
		{
			
		}
		public Person AddPerson()
		{
			throw new NotImplementedException();
		}

		public void AddCarById(int carId)
		{
			throw new NotImplementedException();
		}

		

		public void GetDriveById(int driveId)
		{
			throw new NotImplementedException();
		}

		

		public void SaveCar(string description, int seatNumber, float fuelConsumption, int personId)
		{
			throw new NotImplementedException();
		}

		public void SavePerson(string username, string name, string surname, string address, string gender)
		{
			throw new NotImplementedException();
		}

		public void AddCarToPerson(Person person, string model, int seatNumber, double fuelConsumption)
		{
			throw new NotImplementedException();
		}

		public void AddPersonToCarpool(Person person, int carpoolId)
		{
			throw new NotImplementedException();
		}

		public void CreateCarpool(string description)
		{
			throw new NotImplementedException();
		}

		public void CreatePerson(Person person)
		{
			throw new NotImplementedException();
		}

		public void GetCarpoolByUsername(int personId)
		{
			throw new NotImplementedException();
		}

		public void RemovePersonFromCarpool(int carpoolId, int personId)
		{
			throw new NotImplementedException();
		}

		void IGetPersonByUsername.GetPersonByUsername(string username)	//auto implemented ???
		{
			throw new NotImplementedException();
		}
	}
}
