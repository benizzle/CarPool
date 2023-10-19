using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class CarpoolManager
	{
		public List<Carpool> carpools;										//evtl static machen

        public CarpoolManager()
        {
			var listOFLines = CSVHandler.ReadCsv(PathManager.CarpoolPath);
			if (!listOFLines.Any())
				this.carpools = new List<Carpool>();
		}
		public void GetCarpools()
		{
			int i = 0;
			int j = 0;
			Console.WriteLine("List of carpools:");
			foreach (Carpool carpool in this.carpools)
			{
				i++;
				Console.WriteLine($"Carpool Nr.{i}");
				Console.WriteLine($"Driver: {carpool.driver.Name} {carpool.driver.Surname}");
				Console.WriteLine($"Price: {carpool.price}");
				Console.WriteLine($"Number of drives: {carpool.NumberOfDrives}");
				foreach (Person person in carpool.passengers)
				{
					j++;
					Console.WriteLine($"Passenger {j}: {person.Name} {person.Surname}, {person.Address} Gender: {person.Gender}");
				}
			}
		}
    }
}
