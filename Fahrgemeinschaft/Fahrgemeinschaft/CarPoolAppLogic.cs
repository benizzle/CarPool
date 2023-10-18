using System;
using System.Collections.Generic;

namespace Fahrgemeinschaft
{
	public class CarPoolAppLogic
	{
		private PersonManager _personManager;
		public CarPoolAppLogic()
        {
			this._personManager = new PersonManager();
        }

		void CreateNewCarPool(Person driver, string destination, double price)
		{

			Carpool newCarpool = new Carpool(driver, price, destination);
			CarpoolManager.carpools.Add(newCarpool);
			Program.currentcarpool = newCarpool;





				
			
		}

		internal static void AddNewCar(Person person, string model, int seatNumber, double fuelConsumption)
		{
			Car car = new Car(model, seatNumber, fuelConsumption);
			person.cars.Add(car);
		}
		public static List<Car> GetCarList(Person person)
		{
			return Program.currentuser.cars;
		}
		void AddNewPersonToCarPool(Person person, int carpoolid)
		{
			// check if person exists
			//		if not add person
			//		if contiue
			// check seat in carpool
			//	 get carpool by id(carppol manager) -> total seats
			// get persons in carpool by id
			//	- get all that have carpool id
			// check if there is a seat free()
			// -	if free seat 
			//		add new entry personcarpool personid + carpool id

		}

		void AddNewDrive(int driverID, Drive drive)
		{
			this._personManager.GetById(driverID);
		}
		void AddNewPerson(Person driver, Drive drive)
		{
			// schritt 1

		}
		void DeletePeopleFromCarPool(List<int> driverIds)
		{
			foreach (int driverID in driverIds)
			{

			}
		}
	}
}
