using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class Carpool
	{
		public int carpoolId;
		private int NumberOfPassenger;
		public double price;
		public int NumberOfDrives;
		public Person driver;
		public string destination;
		public List<Drive> drives;
		public List<Person> passengers;
		//public List<PoolPerson> personcarpool;

		public Carpool(Person person, double price, string destination)
		{
			this.carpoolId = carpoolId++;
			this.driver = person;
			this.destination = destination;
			this.price = price;
			this.NumberOfPassenger = 0;
			this.NumberOfDrives = 0;
			this.drives = new List<Drive>();
			this.passengers = new List<Person>();
			//this.personcarpool = new List<PoolPerson>();
			//this.personcarpool.Where(e=>e["carpoolid"] == id)
		}

		public void ChangeDriver(Person user)
		{
			this.driver = user;
		}
	}
}
