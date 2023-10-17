using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	internal class PoolPerson
	{
		public List<int> PoolPersons { get; set; }

		public List<int> CreatePoolPersonList(List<Carpool> carpools)
		{
			foreach (Carpool carpool in carpools)
			{
				foreach (Person passenger in carpool.passengers)
				{
					PoolPersons.Add(passenger.id);
				}
			}
			return PoolPersons;
		}



	}
}
