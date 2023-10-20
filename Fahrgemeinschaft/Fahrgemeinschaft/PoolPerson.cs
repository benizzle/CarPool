using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class PoolPerson
	{
		public List<string> PoolPersons { get; set; }

		public List<string> CreatePoolPersonList(List<Carpool> carpools)
		{
			//foreach foreach falsch?
			foreach (Carpool carpool in carpools)
			{
				foreach (Person passenger in carpool.passengers)
				{
					PoolPersons.Add(passenger.Username);
				}
			}
			return PoolPersons;
		}
	}
}
