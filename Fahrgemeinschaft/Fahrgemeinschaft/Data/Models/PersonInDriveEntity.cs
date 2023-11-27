using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Models
{
	internal class PersonInDriveEntity
	{
        public string Username { get; set; }
        public int DriverId { get; set; }
        public bool isDriver { get; set; }

		public PersonInDriveEntity(string username, int driverId, bool isDriver)
		{
			Username = username;
			DriverId = driverId;
			this.isDriver = isDriver;
		}
	}
}
