using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class Carpool
	{
		public int? carpoolId;
		public string description;
		public List<Person> passangers;

		public Carpool(int? carpoolId, string description)
		{
			this.carpoolId = carpoolId;
			this.description = description;
			//this.personcarpool = new List<PoolPerson>();
			//this.personcarpool.Where(e=>e["carpoolid"] == id)
			this.passangers = new List<Person>();
			//this.passangers = 
		}
	}
}
