using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Models
{
	internal class DriveEntity
	{
        public int DriveId { get; set; }
        public string StartPoint { get; set; }
        public string Destination { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public double Price { get; set; }
        public int CarId { get; set; }
        public string DriverUsername { get; set; }
        public int CarpoolId { get; set; }

		public DriveEntity(int driveId, string startPoint, string destination, DateTime starttime, DateTime endtime, double price, int carId, string driverUsername, int carpoolId)
		{
			DriveId = driveId;
			StartPoint = startPoint;
			Destination = destination;
			Starttime = starttime;
			Endtime = endtime;
			Price = price;
			CarId = carId;
			DriverUsername = driverUsername;
			CarpoolId = carpoolId;
		}
	}
}
