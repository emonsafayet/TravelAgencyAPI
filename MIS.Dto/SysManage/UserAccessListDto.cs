using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.SysManage
{
    public class UserAccessListDto
    {
        public MenuModel ParentMenu = new MenuModel();
        public List<MenuModel> ChildMenuList = new List<MenuModel>();
    }

    public class MenuModel
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public Nullable<int> ParentMenuID { get; set; }
        public string MenuNameEng { get; set; }
        public string MenuNameBng { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string MenuURL { get; set; }

        public List<AccessModel> AccessList = new List<AccessModel>();
    }

    public class AccessModel
    {
        public string FieldName { get; set; }
        public bool FieldValue { get; set; }
        public int AccessID { get; set; }
    }
}