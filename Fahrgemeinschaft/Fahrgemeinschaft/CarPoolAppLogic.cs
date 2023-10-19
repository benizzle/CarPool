using System;
using System.Collections.Generic;

namespace Fahrgemeinschaft
{
	public class CarPoolAppLogic
	{
		//private PersonManager _personManager;
		public CarPoolAppLogic carpoolAppLogic;

		public CarPoolAppLogic()
        {
			//this._personManager = new PersonManager();
			this.carpoolAppLogic = new CarPoolAppLogic();

		}

		public static Person LoginExist(string user)
		{
			Person checkperson = null;
			foreach (Person person in Program.personManager.Persons)
			{
				if (user == person.Username)
				{
					checkperson = person;
				}
			}
			return checkperson;
		}

		public static void CreateNewCarPool(Person driver, string destination, double price)
		{
			Carpool newCarpool = new Carpool(driver, price, destination);
			Program.carpoolManager.carpools.Add(newCarpool);
			Program.currentcarpool = newCarpool;
		}

		internal static void AddNewCar(Person person, string model, int seatNumber, double fuelConsumption)
		{
			Car car = new Car(model, seatNumber, fuelConsumption);
			person.cars.Add(car);
		}

		public static List<Car> GetCarList(Person person)
		{
			return person.cars;
		}

		void AddNewPersonToCarPool(Person person)
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

		public static void AddNewDrive(Drive drive)
		{
			Program.currentcarpool.drives.Add(drive);
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
