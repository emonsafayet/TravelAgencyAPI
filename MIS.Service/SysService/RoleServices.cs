using MIS.Data.Repositories;
using MIS.Data.SysModels;
using MIS.Dto.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.SysService
{
    public class RoleServices
    {
        public Exception Error = new Exception();

        //Post

        public Role saveUpdateRole(Role role)
        {
            try
            {
                if (role.Name == null || role.Name == "") throw new Exception("Role Name is empty.");

                if (role != null && role.ID > 0)
                {
                    role.UpdateOn = DateTime.Now;

                    return new SysManageGenericRepository<Role>().Update(role, r => r.ID == role.ID);
                }
                else
                {
                    role.CreatedOn = DateTime.Now;

                    return new SysManageGenericRepository<Role>().Insert(role);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // GET

        public List<Role> getRoleList()
        {
            try
            {
                return new SysManageGenericRepository<Role>().GetAll().OrderByDescending(r => r.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }
    }
}