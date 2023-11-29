using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrgemeinschaft.Business.Interfaces;

namespace Fahrgemeinschaft.Business
{
	internal interface IServiceManager : IAddCarToPerson, IAddPersonToCarpool, ICreateCarpool, ICreatePerson, IGetCarpoolsByUsername, IGetCarsByUsername, IGetPersons, IRemovePersonFromCarpool
	{
	}
}
