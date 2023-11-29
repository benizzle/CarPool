using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Business.Interfaces
{
	public interface ICreatePerson
	{
		void CreatePerson(string username, string name, string surname, string address, string gender);
	}
}
