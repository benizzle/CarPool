using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Interfaces
{
	internal interface ISaveCar
	{
		void SaveCar(string description, int seatNumber, float fuelConsumption, int personId);
	}
}
