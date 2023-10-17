using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	internal class Program
	{
		public static List<Carpool> carpools = new List<Carpool>();
		public static List<Person> users = new List<Person>();
		public static Person currentuser = null;
		public static Carpool currentcarpool = null;

		public static string path1 = @"C:\\repos\\Fahrgemeinschaft\\PersonList.csv";
		//public static string path2 = @"C:\\repos\\Fahrgemeinschaft\\CarpoolList.csv";
		static void Main(string[] args)
		{
			List<string> userlist = CSVHandler.ReadCsv(path1);
			users = SetPersonList(userlist);
			//List<string> carpoollist = CSVHandler.ReadCsv(path1);
			//users = SetCarpoolList(carpoollist);

			while (true)
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
				Console.WriteLine("5: Add/Change driver");
				Console.WriteLine("6: Add new passenger");
				Console.WriteLine("7: Create new Drive");
				Console.WriteLine("8: List Drives");
				Console.WriteLine("0: Save & Logout");
				

				userChoice = Convert.ToInt32(Console.ReadLine());
				switch (userChoice)
				{
					case 0:	//logout
						currentuser = null;
						currentcarpool = null;
						var listOfUsers = GetPersonStringList(users);
						//var listOfUsers2 = users.Where(person => person.username == "Schmidt").Select(person => person.ToString());
						CSVHandler.WriteCsv(listOfUsers, path1);
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

							Car myCar = new Car(uCarModel, uSeatNumber, uFuel);
							currentuser.cars.Add(myCar);
							Console.WriteLine("Car added!");
						}
						catch (Exception)
						{
                            Console.WriteLine("!!! Error - Only enter a number !!!");
                        }
						break;
					case 2: //List your cars
						if (currentuser.cars.Count() == 0)
						{
							Console.WriteLine("No cars yet!");
						}
						else
						{
							Console.WriteLine("List of cars:");

							foreach (Car car in currentuser.cars)
							{
								Console.WriteLine($" ");
								Console.WriteLine($"Model: {car.model}");
								Console.WriteLine($"Free seats: {car.seatNumber}");
								Console.WriteLine($"Fuel consumption: {car.fuelConsumption}");
							}
						}
						break;
					case 3: //Add new carpool
						AddCarpool();
						break;
					case 4: //List/manage carpools
						if (carpools.Count() == 0)
						{
							Console.WriteLine("No carpools yet!");
						}
						else
						{
							GetCarpools();
							Console.WriteLine("Choose carpool to manage");
							try
							{
								int cpchoice = Convert.ToInt16(Console.ReadLine()) - 1;
								currentcarpool = carpools[cpchoice];
							}
							catch (Exception)
							{
								Console.WriteLine("!!! Error - Only enter a number !!!");
							}

							Console.WriteLine("Manage your carpool");
							Console.WriteLine("1: startposition");
							Console.WriteLine("2: destination");





						}
						break;
					case 5: //Change driver
						if (carpools.Count() == 0)
						{
							Console.WriteLine("No carpool available - first create carpool");
						}
						else if (carpools.Count() == 1)
						{
							DriverChange();
						}
						else if (carpools.Count() > 1)
						{
							GetCarpools();

							Console.WriteLine("Wich Carpool?");
							try
							{
								int cpchoice = Convert.ToInt16(Console.ReadLine()) - 1;
								currentcarpool = carpools[cpchoice];
							}
							catch (Exception)
							{
								Console.WriteLine("!!! Error - Only enter a number !!!");
							}

							DriverChange();
						}
						break;
					case 6: //Add new passenger
						if (carpools.Count() == 0)
						{
							Console.WriteLine("No carpools yet - First create carpool to add passengers");
						}
						else if (carpools.Count() == 1)
						{
							AddPerson();
						}
						else if (carpools.Count() > 1)
						{
							GetCarpools();
							Console.WriteLine("Wich Carpool?");
							try
							{
								int cpchoice = Convert.ToInt16(Console.ReadLine()) - 1;
								currentcarpool = carpools[cpchoice];
							}
							catch (Exception)
							{
								Console.WriteLine("!!! Error - Only enter a number !!!");
							}

							AddPerson();
						}
						break;
					case 7: //Create new Drive
						if (carpools.Count() == 0)
						{
							Console.WriteLine("No Carpool!");
							AddCarpool();
						}
						else if (carpools.Count() > 1)
						{
							GetCarpools();
							Console.WriteLine("Wich Carpool?");
							int cpchoice = Convert.ToInt16(Console.ReadLine());
							cpchoice--;
							currentcarpool = carpools[cpchoice];

							Console.WriteLine("Create new Drive");
						}
						Console.WriteLine("Start Position (Bsp. Weikersheim)");
						string uStart = Console.ReadLine();
						Console.WriteLine("Destination");
						string uDest = (Console.ReadLine());
						Console.WriteLine("Distance");
						double uDistance = Convert.ToDouble(Console.ReadLine());
						Console.WriteLine("Start time HH:MM");
						try
						{
							DateTime uTime = Convert.ToDateTime(Console.ReadLine());
							Drive newDrive = new Drive(uStart, uDest, uDistance, uTime);
							currentcarpool.drives.Add(newDrive);
							currentcarpool.NumberOfDrives++;
						}
						catch(Exception) 
						{ 
							Console.WriteLine("!!! Error - Insert right format HH:MM !!!"); 
						}
						break;
					case 8: //List Drives
						if (carpools.Count() == 0)
						{
							Console.WriteLine("No Drives and no carpools found! First create carpool!");

						}
						else if (carpools.Count() == 1)
						{
							GetDrives();
						}
						else if (carpools.Count() > 2)
						{
							GetCarpools();
							Console.WriteLine("From wich carpool do you want your drives?");
							try
							{
								int input = Convert.ToInt32(Console.ReadLine()) - 1;
								currentcarpool = carpools[input];
								GetDrives();
							}
							catch (Exception)
							{
								Console.WriteLine("!!! Error - Only enter a number !!!"); 
							}
						}
						break;
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

				int uInput = Convert.ToInt16(Console.ReadLine());

				if (uInput == 1)
				{
					Console.WriteLine("Login: Enter Username: ");
					string loginname = Console.ReadLine();
					foreach (Person user in users)
					{
						if (loginname == user.username)
						{
							currentuser = user;
							Console.WriteLine("Logged in!");
						}
					}
					if (currentuser == null)
					{
						Console.WriteLine("!!! Error - User don't exist!");
					}
				}
				else if (uInput == 2)
				{
					AddPerson();
					var listOfUsers = GetPersonStringList(users);
					//var listOfUsers2 = users.Where(person => person.username == "Schmidt").Select(person => person.ToString());
					CSVHandler.WriteCsv(listOfUsers, path1);
				}
			}
		}
		public static void AddPerson()
		{
			bool x = true;
			Console.WriteLine("Username: ");
			string reguser = Console.ReadLine();
			foreach (Person person in users)
			{
				if (reguser == person.username)
				{
					x = false;
				}
			}
			if (x == true)
			{
				Console.WriteLine("Enter name: ");
				string uName = (Console.ReadLine());
				Console.WriteLine("Enter surname: ");
				string uSurname = (Console.ReadLine());
				Console.WriteLine("We need your address please: ");
				string uAddress = (Console.ReadLine());
				Console.WriteLine("And your gender please: m/w/d");
				string uGender = (Console.ReadLine());
				Person user1 = new Person(reguser, uName, uSurname, uAddress, uGender);
				currentcarpool.passengers.Add(user1);
			}
			else 
			{ 
				Console.WriteLine("!!! Error - User already exist !!!"); 
			}
		}
		
		public static List<Person> SetPersonList(List<string> list)
		{
			List<Person> users = new List<Person>();

			foreach (string line in list)
			{
				string[] item = line.Split(';');

				Person person = new Person(item[0].Trim('"'), item[1].Trim('"'), item[2].Trim('"'), item[3].Trim('"'), item[4].Trim('"'));
				users.Add(person);
			}
			return users;
		}
		public static List<string> GetPersonStringList(List<Person> users)
		{
			List<string> list = new List<string>();

			foreach (var person in users)
			{
				list.Add(person.ToString());
			}
			return list;
		}
		static void GetCarpools()
		{
			int i = 0;
			int j = 0;
			Console.WriteLine("List of carpools:");
			foreach (Carpool carpool in carpools)
			{
				i++;
				Console.WriteLine($"Carpool Nr.{i}");
				Console.WriteLine($"Driver: {carpool.driver.name} {carpool.driver.surname}");
				Console.WriteLine($"Price: {carpool.price}");
				Console.WriteLine($"Number of drives: {carpool.NumberOfDrives}");
				foreach (Person person in carpool.passengers)
				{
					j++;
					Console.WriteLine($"Passenger {j}: {person.name} {person.surname}, {person.address} Gender: {person.gender}");
				}
			}
		}
		static void AddCarpool()
		{
			Console.WriteLine("Add carpool: Add price!");
			double newprice = Convert.ToDouble(Console.ReadLine());

			Carpool newCarpool = new Carpool(currentuser, newprice);
			currentcarpool = newCarpool;
			carpools.Add(newCarpool);
		}
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
						Console.WriteLine($"Passenger {k}: {person.name} {person.surname}, {person.address} Gender: {person.gender}");
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
			Console.WriteLine("Change driver");
			Console.WriteLine($"Current driver: {currentcarpool.driver}");
			int j = 0;
			Console.WriteLine("List of passengers:");
			foreach (Person person in currentcarpool.passengers)
			{
				j++;
				Console.WriteLine($"Passenger {j}: {person.name} {person.surname}, {person.address} Gender: {person.gender}");
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
	}
}
