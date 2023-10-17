using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	internal class Carpool
	{
		public int carpoolId;
		private int NumberOfPassenger;
		public double price;
		public int NumberOfDrives;
		public int driverID;
		public List<Drive> drives;
		public List<Person> passengers;
		//public List<PoolPerson> personcarpool;

		public Carpool(Person person, double price)
		{
			this.carpoolId = carpoolId++;
			this.drives = new List<Drive>();
			this.NumberOfDrives = 0;
			this.price = price;
			this.driver = person;
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
