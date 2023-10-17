using System.Collections.Generic;

namespace Fahrgemeinschaft
{
	class CarPoolAppLogic
	{
		private PersonManager _personManager;
		public CarPoolAppLogic()
        {
			this._personManager = new PersonManager();
        }

		void CreateNewCarPool(Person driver, Drive drive)
		{ 
			
		}
		void AddNewDrive(int driverID, Drive drive)
		{
			this._personManager.GetById(driverID);
		}
		void AddNewPerson(Person driver, Drive drive)
		{

		}
		void DeletePeopleFromCarPool(List<int> driverIds)
		{
			foreach (int driverID in driverIds)
			{

			}
		}
	}
}
