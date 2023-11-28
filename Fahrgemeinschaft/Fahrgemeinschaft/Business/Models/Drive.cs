using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class Drive
	{
		public int? driveId;
		public string startpoint;
		public string destination;
		public DateTime startTime;
		public DateTime endTime;
		public double price;
		public int carId;
		public string driverUsername;
		public int carpoolId;

		public Drive(int? driveId, string startpoint, string destination, DateTime startTime, DateTime endTime, double price, int carId, string driverUsername, int carpoolId)
		{
			this.driveId = driveId;
			this.startpoint = startpoint;
			this.destination = destination;
			this.startTime = startTime;
			this.endTime = endTime;
			this.price = price;
			this.carId = carId;
			this.driverUsername = driverUsername;
			this.carpoolId = carpoolId;
		}
	}
}
