using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Models
{
	internal class PersonsCarpoolEntity
	{
        public string Username { get; set; }
        public int CarpoolId { get; set; }

		public PersonsCarpoolEntity(string username, int carpoolId)
		{
			Username = username;
			CarpoolId = carpoolId;
		}
	}
}
