using System;
using System.Collections.Generic;
using System.Linq;

namespace Fahrgemeinschaft
{
	public class PersonManager
	{
		public List<Person> Persons;

        public PersonManager()
        {
			var listOFLines = CSVHandler.ReadCsv(PathManager.PersonPath);
			if (!listOFLines.Any())
			{
				this.Persons = new List<Person>();
			}
			else
			{
				this.Persons = new List<Person>();
				foreach (var line in listOFLines)
				{
					string[] items = line.Split(';');
					Person person = new Person(items[0].Trim('"'), items[1].Trim('"'), items[2].Trim('"'), items[3].Trim('"'), items[4].Trim('"'));
					this.Persons.Add(person);
				}
			}

		}

		public List<string> GetPersonStringList(List<Person> plist)
		{
			List<string> list = new List<string>();

			foreach (Person p in plist)
			{
				list.Add(p.ToString());
			}
			return list;
		}

		public void GetAll()
		{
			CSVHandler.ReadCsv(PathManager.PersonPath);
				// read all from csv	
		}

		void GetByName()
		{ 
			// read all and filter by name
		}
		public void GetByUsername(string username)
		{
			// read all and filter by name
		}

		//void AddSingle()
		//{
		//	CSVHandler.ReadCsv(PathManager.PersonPath);
		//	// read all
		//	// append new
		//	// write all

		//}
	}
}
