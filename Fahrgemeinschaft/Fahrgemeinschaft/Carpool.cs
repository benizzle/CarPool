using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	internal class Carpool
	{
		public int NumberOfPassenger;
		public double price;
		public int NumberOfDrives;
		public Person driver;
		public List<Drive> drives;
		public List<Person> passengers;

		public Carpool(Person person, double price)
		{
			this.drives = new List<Drive>();
			this.NumberOfDrives = 0;
			this.price = price;
			this.driver = person;
			this.passengers = new List<Person>();
		}
		public void ChangeDriver(Person user)
		{
			this.driver = user;
		}
	}
}
