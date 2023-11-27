using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Fahrgemeinschaft.Business;

namespace Fahrgemeinschaft
{
	public class Program
	{
		// HIER FALSCH ABER WOHIN? public static DBManager dbManager = "Data Source=localhost;Initial Catalog=Carpool;Integrated Security=true;"

		public static IPersonFunctions personManager = new PersonManager();
		public static Person currentuser = null;
		public static Carpool currentcarpool = null;
		//public static PersonManager personManager = new PersonManager();
		public static CarpoolManager carpoolManager = new CarpoolManager();
		public static CarPoolAppLogic carpoolAppLogic = new CarPoolAppLogic(personManager, carpoolManager);
		public static bool go = true;

		static void Main(string[] args)
		{
			while (go)
			{
				while (currentuser == null)
				{
					LoginMenu();
				}
				while (currentuser != null)
				{
					UserMenu();
				}
			}
		}
		static void LoginMenu()
		{
			Console.WriteLine("Welcome to Fahrgemeinschaft!");

			while (currentuser == null)
			{
				Console.WriteLine(" ");
				Console.WriteLine("1: Login");
				Console.WriteLine("2: Register");
				try
				{
					int uInput = Convert.ToInt16(Console.ReadLine());
					Person logUser;
					if (uInput == 1)
					{
						Console.WriteLine("Login: Enter Username: ");
						string logName = Console.ReadLine();
						logUser = carpoolAppLogic.LoginExist(logName);
						if (logUser == null)
						{
							Console.WriteLine("!!! Error - User don't exist!");
						}
						else
						{
							currentuser = logUser;
							Console.WriteLine("Logged in!");
						}
					}
					if (uInput == 2)
					{
						AddPerson();
					}
				}
				catch (Exception)
				{
					Console.WriteLine("!!! Error - User don't exist!");
				}
			}
		}

		static void UserMenu()
		{
			int userChoice = 9;
			while (userChoice > 0)
			{
				Console.WriteLine(" ");
				Console.WriteLine("Usermenu");
				Console.WriteLine("1: Add car");
				Console.WriteLine("2: List your cars");
				Console.WriteLine("3: Add new carpool");
				Console.WriteLine("4: List/manage carpools");
				Console.WriteLine("5: Change driver");														//noch rausnehmen?
				Console.WriteLine("6: Add new passenger");
				Console.WriteLine("7: Create new Drive");
				Console.WriteLine("8: List Drives");
				Console.WriteLine("0: Save");
				

				userChoice = Convert.ToInt32(Console.ReadLine());
				switch (userChoice)
				{
					case 0:	//logout + save
						currentuser = null;
						currentcarpool = null;
						var listOfUsers = personManager.GetPersons();
						//go = false;
						break;
					case 1: //Add car
						Console.WriteLine("Add car: Model?");
						string uCarModel = (Console.ReadLine());
						Console.WriteLine("Add car: Free seats?");
						try
						{
							int uSeatNumber = Convert.ToInt16(Console.ReadLine());
							Console.WriteLine("Add car: Fuel consumption? (7 is normal)");
							double uFuel = Convert.ToDouble(Console.ReadLine());
							CarPoolAppLogic.AddNewCar(currentuser, uCarModel, uSeatNumber, uFuel);
							Console.WriteLine("Car added!");
						}
						catch (Exception)
						{
                            Console.WriteLine("!!! Error - Enter number only !!!");
                        }
						break;
					case 2: //List your cars
						List<Car> listOfCars = CarPoolAppLogic.GetCarList(currentuser);
						if (listOfCars.Count() == 0)
						{
							Console.WriteLine("No cars yet!");
						}
						else
						{
							Console.WriteLine("List of cars:");

							foreach (Car car in listOfCars)
							{
								Console.WriteLine($" ");
								Console.WriteLine($"Model: {car.model}");
								Console.WriteLine($"Free seats: {car.seatNumber}");
								Console.WriteLine($"Fuel consumption: {car.fuelConsumption}");
							}
						}
						break;
					case 3: //Add new carpool
						if (currentuser.Cars.Count() > 0)
						{
							Console.WriteLine("Please enter the destination for your new carpool");
							string destination = Console.ReadLine();
							Console.WriteLine("Please enter the price - standard (3-5), business (6-9), luxury (10-20)");
							double price = Convert.ToDouble(Console.ReadLine());
							carpoolAppLogic.CreateNewCarPool(currentuser, destination, price);
							Console.WriteLine("New carpool created and set as your current carpool");
						}
						else 
						{
							Console.WriteLine("You cant create a carpool without a car! Please add car first");
						}
						break;
					case 4: //List/manage carpools
						if (carpoolManager.carpools.Count() > 1)
						{
							carpoolManager.GetCarpools();

							ChooseCarpool();

							ManageCarpoolMenu();
						}
						else if (carpoolManager.carpools.Count() == 1)
						{
							ManageCarpoolMenu();
						}
						else
						{
							Console.WriteLine("No carpools yet!");
						}
						break;
					case 5: //Change driver
						if (carpoolManager.carpools.Count() > 1)
						{
							carpoolManager.GetCarpools();

							ChooseCarpool();

							DriverChange();
						}
						if (carpoolManager.carpools.Count() == 1)
						{
							DriverChange();
						}
						else
						{
							Console.WriteLine("No carpool available - first create carpool");
						}
						break;
					case 6: //Add new passenger
						if (carpoolManager.carpools.Count() > 1)
						{
							carpoolManager.GetCarpools();

							ChooseCarpool();

							AddPerson();

							Person newPerson = personManager.GetLastAdded();

							CarPoolAppLogic.AddNewPersonToCarPool(newPerson);
						}
						else if (carpoolManager.carpools.Count() == 1)
						{
							AddPerson();

							Person newPerson = personManager.GetLastAdded();

							CarPoolAppLogic.AddNewPersonToCarPool(newPerson);
						}						
						else
						{
							Console.WriteLine("No carpools yet - First create carpool to add passengers");
						}
						break;
					case 7: //Create new Drive
						if (carpoolManager.carpools.Count() > 1)
						{
							carpoolManager.GetCarpools();

							ChooseCarpool();

							AddDrive();
						}
						else if (carpoolManager.carpools.Count() == 1)
						{
							AddDrive();
						}
						else
						{
							Console.WriteLine("No carpools yet - First create carpool to add passengers");
						}
						break;
					case 8: //List Drives
						if (carpoolManager.carpools.Count() > 1)
						{
							carpoolManager.GetCarpools();

							ChooseCarpool();

							GetDrives();
						}
						else if (carpoolManager.carpools.Count() == 1)
						{
							GetDrives();
						}
						else
						{
							Console.WriteLine("No Drives and no carpools found! First create carpool!");
						}
						break;
				}
			}
		}

		public static void AddPerson()
		{
			Console.WriteLine("Enter Username: ");
			string loginname = Console.ReadLine();
			Person loginuser = carpoolAppLogic.LoginExist(loginname);
			if (loginuser == null)
			{				
				Console.WriteLine("Enter name: ");
				string uName = (Console.ReadLine());
				Console.WriteLine("Enter surname: ");
				string uSurname = (Console.ReadLine());
				Console.WriteLine("We need your address please: ");
				string uAddress = (Console.ReadLine());
				Console.WriteLine("And your gender please: m/w/d");
				string uGender = (Console.ReadLine());
				Person user1 = new Person(loginname, uName, uSurname, uAddress, uGender);
				personManager.Persons.Add(user1);
				currentuser = user1;
			}
			else
			{
				Console.WriteLine("Username already exist, choose another one");				
			}
		}
		public static void ManageCarpoolMenu()
		{
			bool c = true;
			while (c)
			{
				Console.WriteLine("Manage your carpool");                                   
				Console.WriteLine("1: Change destination");
				Console.WriteLine("2: Change price");
				Console.WriteLine("0: Back");
				try
				{                                                                           //userabfrage anders abfangen bzgl falscheingabe
					int choice = Convert.ToInt16(Console.ReadLine());
					if (choice == 1)
					{
						Console.WriteLine("1: Enter name of destination");
						currentcarpool.destination = Console.ReadLine();
					}
					if (choice == 2)
					{
						Console.WriteLine("2: Enter price");
						currentcarpool.price = Convert.ToDouble(Console.ReadLine());
					}
					if (choice == 0)
					{
						c = false;
					}

				}
				catch (Exception)
				{
					Console.WriteLine("!!! Error - Enter number only !!!");
				}
			}
		}

		public static void ChooseCarpool()
		{
			int i = -1;
			while (i < 0 || i > carpoolManager.carpools.Count())
			{
				Console.WriteLine("Choose your carpool: Enter the number");
				try
				{
					i = Convert.ToInt16(Console.ReadLine()) - 1;
				}
				catch 
				{
					Console.WriteLine("!!! Error - Enter number only");
				}
				if (i > carpoolManager.carpools.Count())
				{
					Console.WriteLine($"Please enter a valid number - you have {carpoolManager.carpools.Count()} carpools");
				}
				else if (i < 0)
				{
					Console.WriteLine($"Please enter a positive and valid number - you have {carpoolManager.carpools.Count()} carpools");
				}
				else
				{
					currentcarpool = carpoolManager.carpools[i];
				}
			}
		}

		public static void AddDrive()
		{
			Console.WriteLine("Create new Drive");
			Console.WriteLine("Start Position (Bsp. Weikersheim)");
			string position = Console.ReadLine();
			Console.WriteLine("Destination");
			string destination = (Console.ReadLine());
			Console.WriteLine("Distance");
			double distance = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Start time HH:MM");
			try
			{
				DateTime time = Convert.ToDateTime(Console.ReadLine());
				Drive newDrive = new Drive(position, destination, distance, time);
				CarPoolAppLogic.AddNewDrive(newDrive);
				currentcarpool.NumberOfDrives++;
			}
			catch (Exception)
			{
				Console.WriteLine("!!! Error - Insert right format HH:MM !!!");
			}
		}

		//public static void AddPerson(string username)								//noch behalten bis ADDPESSENGER fertig ist --- addperson nur für login
		//{
		//	//muss halb in PersonManager
		//	bool x = true;
		//	Console.WriteLine("Username: ");
		//	string reguser = Console.ReadLine();
		//	foreach (Person person in users)
		//	{
		//		if (reguser == person.Username)
		//		{
		//			x = false;
		//		}
		//	}
		//	if (x == true)
		//	{
		//		Console.WriteLine("Enter name: ");
		//		string uName = (Console.ReadLine());
		//		Console.WriteLine("Enter surname: ");
		//		string uSurname = (Console.ReadLine());
		//		Console.WriteLine("We need your address please: ");
		//		string uAddress = (Console.ReadLine());
		//		Console.WriteLine("And your gender please: m/w/d");
		//		string uGender = (Console.ReadLine());
		//		Person user1 = new Person(reguser, uName, uSurname, uAddress, uGender);
		//		currentcarpool.passengers.Add(user1);
		//	}
		//	else 
		//	{ 
		//		Console.WriteLine("!!! Error - User already exist !!!"); 
		//	}
		//}
		
		//public static List<Person> SetPersonList(List<string> list)						// schon in constructor personmanager gepackt
		//{
		//	List<Person> users = new List<Person>();

		//	foreach (string line in list)
		//	{
		//		string[] item = line.Split(';');

		//		Person person = new Person(item[0].Trim('"'), item[1].Trim('"'), item[2].Trim('"'), item[3].Trim('"'), item[4].Trim('"'));
		//		users.Add(person);
		//	}
		//	return users;
		//}
		
		//static void GetCarpools()
		//{
		//	//neu machen wegen passenger abfrage(oder doch nicht, nur bei speicherung in csv?)
		//	int i = 0;
		//	int j = 0;
		//	Console.WriteLine("List of carpools:");
		//	foreach (Carpool carpool in carpools)
		//	{
		//		i++;
		//		Console.WriteLine($"Carpool Nr.{i}");
		//		Console.WriteLine($"Driver: {carpool.driverID.name} {carpool.driverID.surname}");
		//		Console.WriteLine($"Price: {carpool.price}");
		//		Console.WriteLine($"Number of drives: {carpool.NumberOfDrives}");
		//		foreach (Person person in carpool.passengers)
		//		{
		//			j++;
		//			Console.WriteLine($"Passenger {j}: {person.Name} {person.Surname}, {person.Address} Gender: {person.Gender}");
		//		}
		//	}
		//}
		//static void AddCarpool()
		//{
		//	//noch destination hinzufügen
		//	Console.WriteLine("Add carpool: Add price!");
		//	double newprice = Convert.ToDouble(Console.ReadLine());

		//	Carpool newCarpool = new Carpool(currentuser, newprice);
		//	currentcarpool = newCarpool;
		//	carpools.Add(newCarpool);
		//}
		static void GetDrives()
		{
			if (currentcarpool.drives.Count() > 0)
			{
				Console.WriteLine("Your drives");

				foreach (Drive drive in currentcarpool.drives)
				{
					int i = 0;
					i++;
					Console.WriteLine($"Drive: {i}");
					Console.WriteLine($"Start position: {drive.startPosition}");
					Console.WriteLine($"Destination: {drive.destination}");
					Console.WriteLine($"Distance: {drive.distance}");
					Console.WriteLine($"Start time: {drive.startTime}");
					foreach (Person person in currentcarpool.passengers)
					{
						int k = 0;
						k++;
						Console.WriteLine($"Passenger {k}: {person.Name} {person.Surname}, {person.Address} Gender: {person.Gender}");
					}

				}
			}
			else
			{
				Console.WriteLine("No Drives found!");
			}
		}
		static void DriverChange()
		{
			int j = 0;
			if (currentcarpool.passengers.Count() > 0)
			{
				Console.WriteLine("Change driver");
				Console.WriteLine($"Current driver: {currentcarpool.driver.Name} {currentcarpool.driver.Surname}");
				Console.WriteLine("List of passengers:");
				foreach (Person person in currentcarpool.passengers)
				{
					j++;
					Console.WriteLine($"Passenger {j}: {person.Name} {person.Surname}, {person.Address} Gender: {person.Gender}");
				}
				Console.WriteLine("Wich one would you set as driver? Enter the number!");
				try
				{
					int input = Convert.ToInt32(Console.ReadLine()) - 1;
					currentcarpool.ChangeDriver(currentcarpool.passengers[input]);

				}
				catch (Exception)
				{
					Console.WriteLine("!!! Error - Only enter a number !!!");
				}
			}
			else
			{
				Console.WriteLine("No other driver available");
			}
		}
	}
}
