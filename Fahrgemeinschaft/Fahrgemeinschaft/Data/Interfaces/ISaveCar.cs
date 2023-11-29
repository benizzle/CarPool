using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Interfaces
{
	public interface ISaveCar
	{
		void SaveCar(string ownerUsername, string description, int seatNumber);
	}
}
