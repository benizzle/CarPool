using System;
using System.Collections.Generic;
using System.Linq;
using Fahrgemeinschaft.Business;

namespace Fahrgemeinschaft
{
	public class PersonManager : IServiceManagerManager
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

		public Person GetLastAdded()
		{
			int lastElement = this.Persons.Count() - 1;
			Person lastPerson = this.Persons[lastElement];
			return lastPerson;
		}

	}
}
