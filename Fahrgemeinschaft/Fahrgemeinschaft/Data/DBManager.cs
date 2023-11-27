using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Fahrgemeinschaft.Business;
using Fahrgemeinschaft.Data;
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

		// Entities "umwandeln"
		public List<Person> GetPersons() //PersonEntity in Person "umwandeln"
		{
			List<Person> Persons = new List<Person>();
			List<PersonEntity> personEntities = this.GetPersonEntities();




			
			return Persons;
		}

		public List<Car> GetCarsByPersonId(int personId)
		{
			throw new NotImplementedException();
		}

		public Person AddPerson()
		{
			throw new NotImplementedException();
		}

		public void AddCarById(int carId)
		{
			throw new NotImplementedException();
		}

		public void GetCarpoolsByUsername(string username)
		{
			throw new NotImplementedException();
		}

		public void GetCarsByUsername(string username)
		{
			throw new NotImplementedException();
		}

		public void GetDriveById(int driveId)
		{
			throw new NotImplementedException();
		}

		public void GetPersonByUsername(string username)
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

		public void GetPersonById(string username)
		{
			throw new NotImplementedException();
		}
	}
}
