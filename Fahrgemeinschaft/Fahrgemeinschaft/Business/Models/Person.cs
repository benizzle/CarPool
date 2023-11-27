using System.Collections.Generic;

namespace Fahrgemeinschaft
{
	public class Person
	{
		public string Username { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Address { get; set; }
		public string Gender { get; set; }
		public List<Car> Cars;

		public Person(string username, string name, string surname, string address, string gender)
		{
			this.Username = username;
			this.Name = name;
			this.Surname = surname;
			this.Address = address;
			this.Gender = gender;
			this.Cars = new List<Car>();
		}

		public override string ToString()
		{
			return $"\"{this.Username}\";\"{this.Name}\";\"{this.Surname}\";\"{this.Address}\";\"{this.Gender}\"";
		}
	}
}
