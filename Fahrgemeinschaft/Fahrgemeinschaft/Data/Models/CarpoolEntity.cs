using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Data.Models
{
	internal class CarpoolEntity
	{
        public int CarpoolId { get; set; }
        public string Description { get; set; }

		public CarpoolEntity(int carpoolId, string description)
		{
			CarpoolId = carpoolId;
			Description = description;
		}
	}
}
