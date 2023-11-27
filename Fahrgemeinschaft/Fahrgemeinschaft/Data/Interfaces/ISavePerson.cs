using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Interfaces
{
	internal interface ISavePerson
	{
		void SavePerson(string username, string name, string surname, string address, string gender);
	}
}
