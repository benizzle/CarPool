using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	internal class Person
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Address { get; set; }
		public string Gender { get; set; }
		public List<Car> cars;

		public Person(string username, string name, string surname, string address, string gender)
		{
			this.id = id++;
			this.username = username;
			this.name = name;
			this.surname = surname;
			this.address = address;
			this.gender = gender;
			this.cars = new List<Car>();
		}
		public override string ToString()
		{
			return $"\"{this.username}\";\"{this.name}\";\"{this.surname}\";\"{this.address}\";\"{this.gender}\"";
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
