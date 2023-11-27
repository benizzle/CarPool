using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class Drive
	{
		public string startPosition;
		public string destination;
		public double distance;
		public Person driver;

		public DateTime startTime;
		//wer ist fahrer, wer fährt mit, 

		public Drive(string startPosition, string destination, double distance, DateTime startTime)
		{
			this.startPosition = startPosition;
			this.destination = destination;
			this.distance = distance;
			this.startTime = startTime;
		}
	}
}
