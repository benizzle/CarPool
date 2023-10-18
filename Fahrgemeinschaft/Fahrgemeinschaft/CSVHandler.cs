using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class CSVHandler
	{

		public static void WriteCsv(List<string> list , string path)
		{
			using (StreamWriter outputFile = new StreamWriter(path))
			{
				foreach (string line in list)
					outputFile.WriteLine(line);
			}
		}
		public static List<string> ReadCsv(string path)
		{
			List<string> lines = new List<string>();
			if (File.Exists(path))
			{
				using (StreamReader inputFile = new StreamReader(path))
				{
					string line;
					while ((line = inputFile.ReadLine()) != null)
					{
						lines.Add(line);
					}
				}
			}
			return lines;
		}
	}
}
