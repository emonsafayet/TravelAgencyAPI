using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.SysManage
{
	public class RoleDto : BaseEntityDTO
	{ 
		public string Name { get; set; } 
		public Nullable<DateTime> UpdateOn { get; set; }

		public string UpdateBy { get; set; }
	}
}
