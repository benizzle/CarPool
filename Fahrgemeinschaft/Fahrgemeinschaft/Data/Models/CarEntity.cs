using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Models
{
	internal class CarEntity
	{
        public int CarId { get; set; }
        public string OwnerUsername { get; set; }
        public string Description { get; set; }
        public int SeatNumber { get; set; }

		public CarEntity(int carId, string ownerUsername, string description, int seatNumber)
		{
			CarId = carId;
			OwnerUsername = ownerUsername;
			Description = description;
			SeatNumber = seatNumber;
		}
	}
}
