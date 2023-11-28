using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Models
{
	internal class PersonsCarpoolsEntity
	{
        public string Username { get; set; }
        public int CarpoolId { get; set; }

		public PersonsCarpoolsEntity(string username, int carpoolId)
		{
			this.Username = username;
			this.CarpoolId = carpoolId;
		}
	}
}
