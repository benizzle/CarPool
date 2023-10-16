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
		public string username;
		public string name;
		public string surname;
		public string address;
		public string gender;
		public List<Car> cars;

		public Person(string username, string name, string surname, string address, string gender)
		{
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
