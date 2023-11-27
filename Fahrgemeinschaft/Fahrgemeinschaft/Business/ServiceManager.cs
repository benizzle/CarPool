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

        public void AddCarToPerson(Person person, string model, int seatNumber, double fuelConsumption)
		{
			throw new NotImplementedException();
		}

		public void AddPersonToCarpool(Person person, int carpoolId)
		{
			throw new NotImplementedException();
		}

		public void CreateCarpool(string description)
		{
			throw new NotImplementedException();
		}

		public void CreatePerson(Person person)
		{
			throw new NotImplementedException();
		}

		public void GetCarpoolByUsername(int personId)
		{
			throw new NotImplementedException();
		}

		public void GetCarsByPerson(int personId)
		{
			throw new NotImplementedException();
		}

		public List<Person> GetPersons()
		{
			throw new NotImplementedException();
		}

		public void RemovePersonFromCarpool(int carpoolId, int personId)
		{
			throw new NotImplementedException();
		}
	}
}
