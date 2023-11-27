using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Business.Interfaces
{
	internal interface IRemovePersonFromCarpool
	{
		void RemovePersonFromCarpool(int carpoolId, int personId);
	}
}
