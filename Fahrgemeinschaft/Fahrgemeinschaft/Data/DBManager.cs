using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Fahrgemeinschaft.Business;
using Fahrgemeinschaft.Data;
using Fahrgemeinschaft.Data.Interfaces;
using Fahrgemeinschaft.Data.Models;

namespace Fahrgemeinschaft
{
	public class DBManager : IDataLayer, IServiceManager
    {
        public string ConnectionString { get; set; }

        public DBManager(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		// Abfrage von Daten von Entities
		private List<PersonEntity> GetPersonEntities()
		{
			List<PersonEntity> PersonEntities = new List<PersonEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $@"SELECT p.Username, p.Name, p.Surname, p.Address, p.Gender
										FROM [Carpool].[dbo].[Person] as p";	
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonEntities.Add(new PersonEntity(reader["Username"].ToString(), reader["Name"].ToString(), reader["Surname"].ToString(),
														reader["Address"].ToString(), reader["Gender"].ToString()));
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
				string queryString = $@"SELECT p.Username, p.Name, p.Surname, p.Address, p.Gender
										FROM [Carpool].[dbo].[Person] as p
										WHERE p.Username={username}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					return new PersonEntity(reader["Username"].ToString(), reader["Name"].ToString(), reader["Surname"].ToString(),
												reader["Address"].ToString(), reader["Gender"].ToString());
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
				string queryString = $@"SELECT c.CarID, c.OwnerUsername, c.Description, c.Seatnumber
										FROM [Carpool].[dbo].[Car] as c
										WHERE c.CarId={carId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					return new CarEntity(Convert.ToInt32(reader["CarID"]), reader["OwnerUsername"].ToString(), reader["Description"].ToString(),
											Convert.ToInt32(reader["Seatnumber"]));
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
				string queryString = $@"SELECT c.CarID, c.OwnerUsername, c.Description, c.Seatnumber
										FROM [Carpool].[dbo].[Car] as c
										WHERE c.OwnerUsername={username}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					CarEntities.Add(new CarEntity(Convert.ToInt32(reader["CarID"]), reader["OwnerUsername"].ToString(), reader["Description"].ToString(),
											Convert.ToInt32(reader["Seatnumber"])));
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
				string queryString = $@"SELECT c.CarpoolID, c.Description
										FROM [Carpool].[dbo].[Carpool] as c";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					CarpoolEntities.Add(new CarpoolEntity(Convert.ToInt32(reader["CarpoolID"]), reader["Description"].ToString()));
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
				string queryString = $@"SELECT c.CarpoolID, c.Description
										FROM [Carpool].[dbo].[Carpool] as c
										WHERE c.CarpoolID={carpoolId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					return new CarpoolEntity(Convert.ToInt32(reader["CarpoolID"]), reader["Description"].ToString());
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
				string queryString = $@"SELECT d.DriveID, d.Startpoint, d.Destination, d.Starttime, d.Endtime, d.Price, d.CarID, d.DriverUsername, d.CarpoolID
										FROM [Carpool].[dbo].[Drive] as d";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					DriveEntities.Add(new DriveEntity(Convert.ToInt32(reader["DriveID"]), reader["Startpoint"].ToString(), reader["Destination"].ToString(),
														Convert.ToDateTime(reader["Starttime"]), Convert.ToDateTime(reader["Endtime"]), Convert.ToDouble(reader["Price"]),
														Convert.ToInt32(reader["CarID"]), reader["DriverUsername"].ToString(), Convert.ToInt32(reader["CarpoolID"])));
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
				string queryString = $@"SELECT d.DriveID, d.Startpoint, d.Destination, d.Starttime, d.Endtime, d.Price, d.CarID, d.DriverUsername, d.CarpoolID
										FROM [Carpool].[dbo].[Drive] as d
										WHERE d.DriveID={driveId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					return new DriveEntity(Convert.ToInt32(reader["DriveID"]), reader["Startpoint"].ToString(), reader["Destination"].ToString(),
														Convert.ToDateTime(reader["Starttime"]), Convert.ToDateTime(reader["Endtime"]), Convert.ToDouble(reader["Price"]),
														Convert.ToInt32(reader["CarID"]), reader["DriverUsername"].ToString(), Convert.ToInt32(reader["CarpoolID"]));
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
				string queryString = $@"SELECT pd.Username, pd.DriveID, pd.isDriver
										FROM [Carpool].[dbo].[PersonInDrive] as pd";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonInDriveEntities.Add(new PersonInDriveEntity(reader["Username"].ToString(), Convert.ToInt32(reader["DriveID"]), Convert.ToBoolean(reader["isDriver"])));
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
				string queryString = $@"SELECT pd.Username, pd.DriveID, pd.isDriver
										FROM [Carpool].[dbo].[PersonInDrive] as pd
										WHERE pd.DriveID={driveId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonsByDriveId.Add(new PersonInDriveEntity(reader["Username"].ToString(), Convert.ToInt32(reader["DriveID"]), Convert.ToBoolean(reader["isDriver"])));
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
				string queryString = $@"SELECT pd.Username, pd.DriveID, pd.isDriver
										FROM [Carpool].[dbo].[PersonInDrive] as pd
										WHERE pd.Username={username}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					DrivesByUsername.Add(new PersonInDriveEntity(reader["Username"].ToString(), Convert.ToInt32(reader["DriveID"]), Convert.ToBoolean(reader["isDriver"])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return DrivesByUsername;
		}
		private List<PersonsCarpoolsEntity> GetPersonsCarpoolsEntities()
		{
			List<PersonsCarpoolsEntity> PersonsCarpoolEntities = new List<PersonsCarpoolsEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $@"SELECT pc.Username, pc.CarpoolID
										FROM [Carpool].[dbo].[PersonsCarpools] as pc";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonsCarpoolEntities.Add(new PersonsCarpoolsEntity(reader["Username"].ToString(), Convert.ToInt32(reader["CarpoolID"])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return PersonsCarpoolEntities;
		}
		private List<PersonsCarpoolsEntity> GetPersonsCarpoolsEntitiesByCarpoolId(int carpoolId) //alle personen von einem carpool
		{
			List<PersonsCarpoolsEntity> PersonsByCarpoolId = new List<PersonsCarpoolsEntity>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $@"SELECT pc.Username, pc.CarpoolID
										FROM [Carpool].[dbo].[PersonsCarpools] as pc
										WHERE pc.CarpoolID={carpoolId}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					PersonsByCarpoolId.Add(new PersonsCarpoolsEntity(reader["Username"].ToString(), Convert.ToInt32(reader["CarpoolID"])));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return PersonsByCarpoolId;
		}
		private List<Carpool> GetPersonsCarpoolsEntitiesByUsername(string username) //(GetCarpoolsByUsername) alle carpools von einer person
		{
			List<Carpool> CarpoolsByUsername = new List<Carpool>();

			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				string queryString = $@"SELECT pc.CarpoolID, c.Description
										FROM [Carpool].[dbo].[PersonsCarpools] as pc
										RIGHT JOIN [Carpool].[dbo].[Carpool] as c
										ON pc.CarpoolID = c.CarpoolID
										WHERE pc.Username={username}";
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				// Call Read before accessing data.
				while (reader.Read())
				{
					CarpoolsByUsername.Add(new Carpool(Convert.ToInt32(reader["CarpoolID"]), reader["Description"].ToString()));
				}

				// Call Close when done reading.
				reader.Close();
			}
			return CarpoolsByUsername;
		}


		// Entities "umwandeln"
		public List<Person> GetPersons()
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
		public List<Car> GetCarsByUsername(string username)
		{
			List<Car> cars = new List<Car>();
			List<CarEntity> carEntities = this.GetCarEntitiesByUsername(username);

			foreach (CarEntity carEntity in carEntities)
			{
				cars.Add(new Car(carEntity.CarId, carEntity.OwnerUsername, carEntity.Description, carEntity.SeatNumber));
			}
			return cars;
		}
		public Car GetCarById(int carId)
		{
			CarEntity carEntity = this.GetCarEntityById(carId);
			return new Car(carEntity.CarId, carEntity.OwnerUsername, carEntity.Description, carEntity.SeatNumber);
		}
		public void SaveCar(string username, string description, int seatNumber)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				connection.Open();

				string insertQuery = $@"INSERT INTO [Carpool].[dbo].[Car] ([OwnerUsername], [Description],	[Seatnumber])
										VALUES (@OwnerUsername, @Description, @Seatnumber)";
				
				SqlCommand command = new SqlCommand(insertQuery, connection);
								
				command.Parameters.AddWithValue("@OwnerUsername", $"{username}");
				command.Parameters.AddWithValue("@Description", $"{description}");
				command.Parameters.AddWithValue("@Seatnumber", $"{seatNumber}");

				command.ExecuteNonQuery();
			}
		}
		public void SavePerson(string username, string name, string surname, string address, string gender)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				connection.Open();

				string insertQuery = $@"INSERT INTO [Carpool].[dbo].[Person] ([Username], [Name], [Surname], [Address], [Gender])
										VALUES (@Username, @Name, @Surname, @Address, @Gender)";

				SqlCommand command = new SqlCommand(insertQuery, connection);

				command.Parameters.AddWithValue("@Username", $"{username}");
				command.Parameters.AddWithValue("@Name", $"{name}");
				command.Parameters.AddWithValue("@Surname", $"{surname}");
				command.Parameters.AddWithValue("@Address", $"{address}");
				command.Parameters.AddWithValue("@Gender", $"{gender}");

				command.ExecuteNonQuery();
			}
		}
		public List<Carpool> GetCarpools()
		{
			List<Carpool> carpools = new List<Carpool>();
			List<CarpoolEntity> carpoolEntities = this.GetCarpoolEntities();

			foreach (CarpoolEntity carpoolEntity in carpoolEntities)
			{
				carpools.Add(new Carpool(carpoolEntity.CarpoolId, carpoolEntity.Description));
			}
			return carpools;
		}
		public List<Carpool> GetCarpoolsByUsername(string username)
		{
			List<Carpool> carpools = this.GetPersonsCarpoolsEntitiesByUsername(username);
			return carpools;
		}
		public Drive GetDriveById(int driveId)
		{
			DriveEntity driveEntity = GetDriveEntityById(driveId);
			return new Drive(driveEntity.DriveId, driveEntity.StartPoint, driveEntity.Destination, driveEntity.Starttime, driveEntity.Endtime, driveEntity.Price,
								driveEntity.CarId, driveEntity.DriverUsername, driveEntity.CarpoolId);
		}
		public void AddCarToPerson(string username, string description, int seatNumber)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				connection.Open();

				string insertQuery = $@"INSERT INTO [Carpool].[dbo].[Car] ([CarID],	[OwnerUsername], [Description],	[Seatnumber])
										VALUES (@CarID, @OwnerUsername, @Description, @Seatnumber)";

				SqlCommand command = new SqlCommand(insertQuery, connection);

				command.Parameters.AddWithValue("@OwnerUsername", $"{username}");
				command.Parameters.AddWithValue("@Description", $"{description}");
				command.Parameters.AddWithValue("@Seatnumber", $"{seatNumber}");

				command.ExecuteNonQuery();
			}
		}
		public void AddPersonToCarpool(string username, int carpoolId)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				connection.Open();

				string insertQuery = $@"INSERT INTO [Carpool].[dbo].[PersonsCarpools] ([Username], [CarpoolID])
										VALUES (@Username, @CarpoolID)";

				SqlCommand command = new SqlCommand(insertQuery, connection);

				command.Parameters.AddWithValue("@Username", $"{username}");
				command.Parameters.AddWithValue("@CarpoolID", $"{carpoolId}");

				command.ExecuteNonQuery();
			}
		}
		public void CreateCarpool(string description)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				connection.Open();

				string insertQuery = $@"INSERT INTO [Carpool].[dbo].[Carpool] ([CarpoolID], [Description])
										VALUES (@CarpoolID, @Description)";

				SqlCommand command = new SqlCommand(insertQuery, connection);

				command.Parameters.AddWithValue("@Description", $"{description}");

				command.ExecuteNonQuery();
			}
		}
		public void CreatePerson(string username, string name, string surname, string address, string gender)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				connection.Open();

				string insertQuery = $@"INSERT INTO [Carpool].[dbo].[Person] ([Username], [Name], [Surname], [Address], [Gender])
										VALUES (@Username, @Name, @Surname, @Address, @Gender)";

				SqlCommand command = new SqlCommand(insertQuery, connection);

				command.Parameters.AddWithValue("@Username", $"{username}");
				command.Parameters.AddWithValue("@Name", $"{name}");
				command.Parameters.AddWithValue("@Surname", $"{surname}");
				command.Parameters.AddWithValue("@Address", $"{address}");
				command.Parameters.AddWithValue("@Gender", $"{gender}");

				command.ExecuteNonQuery();
			}
		}
		public void RemovePersonFromCarpool(string username, int carpoolId)
		{
			using (SqlConnection connection = new SqlConnection(this.ConnectionString))
			{
				connection.Open();

				string insertQuery = $@"DELETE FROM [Carpool].[dbo].[PersonsCarpools]
										WHERE Username = @Username AND CarpoolID = @CarpoolId";

				SqlCommand command = new SqlCommand(insertQuery, connection);

				command.Parameters.AddWithValue("@Username", $"{username}");
				command.Parameters.AddWithValue("@carpoolId", $"{carpoolId}");

				command.ExecuteNonQuery();
			}
		}

	}
}
