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
		public char gender;
		public List<Car> cars;

		// foo
		public Person(string username, string name, string surname, string address, char gender)
		{
			this.username = username;
			this.name = name;
			this.surname = surname;
			this.address = address;
			this.gender = gender;
			this.cars = new List<Car>();
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
