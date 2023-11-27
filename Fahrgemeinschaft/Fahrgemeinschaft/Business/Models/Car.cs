using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class Car
	{
		public string model;
		public int seatNumber;
		public double fuelConsumption;

		public Car(string model, int seatNumber, double fuelConsumption)
		{
			this.model = model;
			this.seatNumber = seatNumber;
			this.fuelConsumption = fuelConsumption;
		}
	}
}
