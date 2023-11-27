using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Business.Interfaces
{
	internal interface ICreatePerson
	{
		void CreatePerson(Person person);
	}
}
