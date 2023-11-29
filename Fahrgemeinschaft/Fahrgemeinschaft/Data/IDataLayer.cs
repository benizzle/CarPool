using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrgemeinschaft.Business.Interfaces;
using Fahrgemeinschaft.Data.Interfaces;

namespace Fahrgemeinschaft.Data
{
	public interface IDataLayer : Interfaces.IGetCarpoolsByUsername, Interfaces.IGetCarsByUsername, IGetDriveById, IGetPersonByUsername, Interfaces.IGetPersons, ISaveCar, ISavePerson
	{
	}
}
