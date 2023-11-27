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
		public Person driver;
		public string description;
		public List<Drive> drives;
		public List<Person> passengers;
		//public List<PoolPerson> personcarpool;

		public Carpool(Person person, string description)
		{
			this.driver = person;
			this.description = description;
			this.drives = new List<Drive>();
			this.passengers = new List<Person>();
			//this.personcarpool = new List<PoolPerson>();
			//this.personcarpool.Where(e=>e["carpoolid"] == id)
		}
		public Carpool(int carpoolId, Person driver, string description)
		{
			this.driver = driver;
			this.description = description;
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
