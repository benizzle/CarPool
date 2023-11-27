using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrgemeinschaft.Business.Interfaces;
using Fahrgemeinschaft.Data.Interfaces;

namespace Fahrgemeinschaft.Data
{
	internal interface IDataLayer : IAddCarById, IGetCarpoolsByUsername, IGetCarsByUsername, IGetDriveById, IGetPersonByUsername, Interfaces.IGetPersons, ISaveCar, ISavePerson
	{
	}
}
