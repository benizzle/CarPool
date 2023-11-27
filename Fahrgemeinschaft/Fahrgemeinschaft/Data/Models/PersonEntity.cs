using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Models
{
	internal class PersonEntity
	{
		public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

		public PersonEntity(string username, string name, string surname, string address, string gender)
		{
			Username = username;
			Name = name;
			Surname = surname;
			Address = address;
			Gender = gender;
		}
	}
}
