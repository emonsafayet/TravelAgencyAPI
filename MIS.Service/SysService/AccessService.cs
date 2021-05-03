using MIS.BusinessService.Map;
using MIS.Data.Repositories;
using MIS.Data.SysModels;
using MIS.Dto.MenuDto;
using MIS.Dto.SysManage;
using MIS.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.SysService
{
    public class AccessService
    {
        public Exception Error = new Exception();
        private SysManageEntities context = new SysManageEntities();

        public bool saveUpdateUserAccess(string employeecode, bool accesstype, int menuID, int accessID, string entryBy)
        {
            try
            {
                //save access
                if (accesstype)
                {
                    UserAccessTbl access = new UserAccessTbl();
                    access.EmployeeCode = employeecode;
                    access.MenuID = menuID;
                    access.AccessID = accessID;
                    access.CreatedBy = entryBy;
                    access.CreatedOn = DateTime.Now;
                    new SysManageGenericRepository<UserAccessTbl>().Insert(access);
                }
                else  //remove access
                {
                    UserAccessTbl ExistAccess = context.UserAccessTbls.Where(a => a.MenuID == menuID &&
                     a.AccessID == accessID && a.EmployeeCode == employeecode).FirstOrDefault();

                    if (ExistAccess != null)
                    {
                        context.UserAccessTbls.Remove(ExistAccess);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public List<UserAccessListDto> getAllMenuAccessListByUser(string EmployeeCode)
        {
            List<UserAccessListDto> MenuListWithAccess = new List<UserAccessListDto>();
            UserAccessListDto menuAccessItem = new UserAccessListDto();

            SqlParameter parameter = new SqlParameter("@EmployeeCode", EmployeeCode);
            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(parameter);

            DataSet results = new SysManageGenericRepository<Menu>().getMultipleDataSetUsingSP("getAllMenuAndUserAccess", parameterList);

            List<MenuModel> ParentMenuList = ConvertData.ConvertDataTable<MenuModel>(results.Tables[0]);
            List<MenuModel> SubMenuList = ConvertData.ConvertDataTable<MenuModel>(results.Tables[1]);
            List<UserAccessType> AllAccessList = ConvertData.ConvertDataTable<UserAccessType>(results.Tables[2]);
            List<UserAccessTbl> UseAccessList = ConvertData.ConvertDataTable<UserAccessTbl>(results.Tables[3]);

            foreach (MenuModel ParrentMenu in ParentMenuList)
            {
                menuAccessItem = new UserAccessListDto();
                menuAccessItem.ParentMenu = ParrentMenu;

                //Get Parent menu access list
                menuAccessItem.ParentMenu.AccessList = getMenuAccessList(AllAccessList, UseAccessList, menuAccessItem.ParentMenu.ID);

                foreach (MenuModel menu in SubMenuList)
                {
                    if (menuAccessItem.ParentMenu.ID == menu.ParentMenuID)
                    {
                        menu.AccessList = getMenuAccessList(AllAccessList, UseAccessList, menu.ID);

                        menuAccessItem.ChildMenuList.Add(menu);
                    }
                }

                menuAccessItem.ChildMenuList = menuAccessItem.ChildMenuList.OrderBy(c => c.DisplayOrder).ToList();

                MenuListWithAccess.Add(menuAccessItem);
            }

            return MenuListWithAccess;
        }

        public List<AccessModel> getMenuAccessList(List<UserAccessType> AllAccessList, List<UserAccessTbl> UserAccessList, int MenuID)
        {
            List<AccessModel> AccessList = new List<AccessModel>();

            foreach (UserAccessType item in AllAccessList)
            {
                var IsHasAccess = UserAccessList.Where(a => a.AccessID == item.ID && a.MenuID == MenuID).FirstOrDefault();

                if (IsHasAccess == null) AccessList.Add(new AccessModel { FieldName = item.PermissionName, FieldValue = false, AccessID = item.ID });
                else AccessList.Add(new AccessModel { FieldName = item.PermissionName, FieldValue = true, AccessID = item.ID });
            }

            return AccessList;
        }
    }
}