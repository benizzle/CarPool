﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft.Business.Interfaces
{
	public interface IRemovePersonFromCarpool
	{
		void RemovePersonFromCarpool(string username, int carpoolId);
	}
}
