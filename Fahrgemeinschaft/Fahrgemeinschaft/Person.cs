using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class Person
	{
		public string Username { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Address { get; set; }
		public string Gender { get; set; }
		public List<Car> cars;

		public Person(string username, string name, string surname, string address, string gender)
		{
			//Keine ID erstellen, username ist eindeutig!
			this.Username = username;
			this.Name = name;
			this.Surname = surname;
			this.Address = address;
			this.Gender = gender;
			this.cars = new List<Car>();
		}

		public override string ToString()
		{
			return $"\"{this.Username}\";\"{this.Name}\";\"{this.Surname}\";\"{this.Address}\";\"{this.Gender}\"";
		}
		
		public void GetCarList(List<Car> cars)
		{
			//noch aendern in programm.cs
			foreach (Car car in cars)
			{
				Console.WriteLine($"Model: {car.model}");
				Console.WriteLine($"Model: {car.seatNumber}");
				Console.WriteLine($"Model: {car.fuelConsumption}");
			}
		}
	}
}
