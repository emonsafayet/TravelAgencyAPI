using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.MenuDto
{
    public class UserMenuDto
    {
        public Menu ParentMenu = new Menu();

        public List<Menu> ChildMenuList = new List<Menu>();
    }
}