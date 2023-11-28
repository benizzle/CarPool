using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class Car
	{
		public int? carId;
		public string username;
		public string description;
		public int seatNumber;

		public Car(int? carId, string username, string description, int seatNumber)
		{
			this.carId = carId;
			this.username = username;
			this.description = description;
			this.seatNumber = seatNumber;
		}
	}
}
