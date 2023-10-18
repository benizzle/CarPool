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
				this.Persons = new List<Person>();
			// convert list of strings to list of persons
		}

		public List<string> GetPersonStringList(List<Person> Persons)
		{
			List<string> list = new List<string>();

			foreach (var person in Persons)
			{
				list.Add(person.ToString());
			}
			return list;
		}

		public Person LoginExist(string user)
		{
			Person currentuser = null;
			foreach (Person person in Persons)
			{
				if (user == person.Username)
				{
					currentuser = person;
				}
			}
			return currentuser;
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
