using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
	public class PathManager
	{
		public static string PersonPath { get { return @"C:\\repos\\Fahrgemeinschaft\\PersonList.csv"; } }
		public static string CarpoolPath { get { return @"C:\\repos\\Fahrgemeinschaft\\CarpoolList.csv"; } }
		public static string DriverPath { get { return @"C:\\repos\\Fahrgemeinschaft\\DriverList.csv"; } }
		public static string DrivePath { get { return @"C:\\repos\\Fahrgemeinschaft\\DriveList.csv"; } }
		public static string CarpoolPersonPath { get { return @"C:\\repos\\Fahrgemeinschaft\\CarpoolPersonList.csv"; } }

		//so nicht, dann eher in DBManager
		//public static string ConnectionString { get { return "Data Source = localhost; Initial Catalog = Carpool; Integrated Security = true;"; } }
		//public static string PersonQuery { get { return "SELECT * FROM [Carpool].[dbo].[Person]"; } }
		//public static string CarQuery { get { return "SELECT * FROM [Carpool].[dbo].[Car]"; } }
		//public static string CarpoolQuery { get { return "SELECT * FROM [Carpool].[dbo].[Carpool]"; } }
		//public static string DriveQuery { get { return "SELECT * FROM [Carpool].[dbo].[Drive]"; } }


	}
}
