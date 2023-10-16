using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	internal class Drive
	{
		public string startPosition;
		public string destination;
		public double distance;
		public DateTime startTime;

		public Drive(string startPosition, string destination, double distance, DateTime startTime)
		{
			this.startPosition = startPosition;
			this.destination = destination;
			this.distance = distance;
			this.startTime = startTime;
		}
	}
}
