using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Business.Interfaces
{
	public interface IAddCarToPerson
	{
		void AddCarToPerson(string username, string description, int seatNumber);
	}
}
