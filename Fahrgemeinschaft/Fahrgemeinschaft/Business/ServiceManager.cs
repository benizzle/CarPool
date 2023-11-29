using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Business
{
	internal class ServiceManager : IServiceManager
	{
		public IServiceManager serviceManager;

		public ServiceManager(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public void AddCarToPerson(string username, string description, int seatNumber)
		{
			throw new NotImplementedException();
		}

		public void AddPersonToCarpool(string username, int carpoolId)
		{
			throw new NotImplementedException();
		}

		public void CreateCarpool(string description)
		{
			throw new NotImplementedException();
		}

		public void CreatePerson(string username, string name, string surname, string address, string gender)
		{
			throw new NotImplementedException();
		}

		public List<Carpool> GetCarpoolsByUsername(string username)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetCarsByUsername(string username)
		{
			throw new NotImplementedException();
		}

		public List<Person> GetPersons()
		{
			throw new NotImplementedException();
		}

		public void RemovePersonFromCarpool(string username, int carpoolId)
		{
			throw new NotImplementedException();
		}
	}
}
