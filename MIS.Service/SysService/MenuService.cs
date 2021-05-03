using MIS.Data.Repositories;
using MIS.Data.SysModels;
using MIS.Dto.MenuDto;
using MIS.Dto.SysManage;
using MIS.Library;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.SysService
{
    public class MenuService
    {
        public Exception Error = new Exception();

        public List<Application> GetApplicationList()
        {
            try
            {
                return new SysManageGenericRepository<Application>().Find(p => p.IsActive == true).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public bool IsUserHasMenuPermission(IpInfoDto ipInfoDto)
        {
            try
            {
                string MenuURL = JSONSerialize.DecodeBase64(ipInfoDto.routePath);

                if (MenuURL.Length <= 0) return false;

                MenuURL = MenuURL.Substring(1, MenuURL.Length - 2);

                var MenuItem = new SysManageGenericRepository<Menu>().Find(i => i.MenuURL == MenuURL).FirstOrDefault();
                if (MenuItem == null) return false;

                var emp = new SysManageGenericRepository<UserTbl>().Find(i => i.UserName == ipInfoDto.UserName).FirstOrDefault();
                if (emp == null) return false;

                var AccessItem = new SysManageGenericRepository<UserAccessTbl>().Find(i => i.MenuID == MenuItem.ID && i.EmployeeCode == emp.EmployeeCode).FirstOrDefault();
                if (AccessItem == null) return false;

                //client informations
                BrowsingLog log = new BrowsingLog();

                List<ClientIPInfoDto> client = JSONSerialize.getJSON<ClientIPInfoDto>(ipInfoDto.IpAddressDetails);

                if (client.Count > 0)
                {
                    //user infos
                    log.ApplicationID = 1;
                    log.ApplicationVersion = "0.0.1";
                    log.MenuID = MenuItem.ID;
                    log.EmployeeCode = ipInfoDto.EmployeeCode;

                    //device infos
                    log.BrowserName = client[0].ClientDeviceInfoDto.browser;
                    log.BrowserVersion = client[0].ClientDeviceInfoDto.browser_version;
                    log.Device = client[0].ClientDeviceInfoDto.device;
                    log.DeviceType = client[0].ClientDeviceInfoDto.deviceType;
                    log.OS = client[0].ClientDeviceInfoDto.os;
                    log.OSVersion = client[0].ClientDeviceInfoDto.os_version;
                    log.UserAgent = client[0].ClientDeviceInfoDto.userAgent;
                    log.RequestedOn = DateTime.Now;

                    //network info
                    log.City = client[0].city;
                    log.Country = client[0].country;
                    log.CountryCode = client[0].countryCode;
                    log.ISPName = client[0].org;
                    log.ISPName = client[0].org;
                    log.latitude = client[0].lat;
                    log.longitude = client[0].lon;
                    log.ZipCode = client[0].zip;
                    log.RegionName = client[0].regionName;
                    log.TimeZone = client[0].timezone;

                    new SysManageGenericRepository<BrowsingLog>().Insert(log);
                }

                return true;
            }
            catch (Exception ex) { Error = ex; return false; }
        }

        public List<UserMenuDto> GetAllMenuList()
        {
            try
            {
                List<UserMenuDto> MenuList = new List<UserMenuDto>();
                List<Menu> ParentMenuList = new SysManageGenericRepository<Menu>().Find(p => p.ParentMenuID == null).ToList();
                if (ParentMenuList == null) throw new Exception("No parrent found.");

                List<Menu> SubMenuList = new SysManageGenericRepository<Menu>().Find(p => p.ParentMenuID != null).ToList();

                foreach (Menu ParrentMenu in ParentMenuList)
                {
                    UserMenuDto userMenuDto = new UserMenuDto();
                    userMenuDto.ParentMenu = ParrentMenu;

                    foreach (Menu menu in SubMenuList)
                    {
                        if (userMenuDto.ParentMenu.ID == menu.ParentMenuID)
                        {
                            userMenuDto.ChildMenuList.Add(menu);
                        }
                    }

                    userMenuDto.ChildMenuList = userMenuDto.ChildMenuList.OrderBy(c => c.DisplayOrder).ToList();

                    MenuList.Add(userMenuDto);
                }

                MenuList = MenuList.OrderBy(m => m.ParentMenu.DisplayOrder).ToList();

                return MenuList;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<UserMenuDto> GetUserMenuList(string EmployeeCode)
        {
            try
            {
                List<UserMenuDto> MenuList = new List<UserMenuDto>();
                List<Menu> ParentMenuList = new SysManageGenericRepository<Menu>().Find(p => p.IsActive == true && p.ParentMenuID == null).ToList();

                List<Menu> UserAccessMenuList = new SysManageGenericRepository<Menu>().FindUsingSP("getUserMenuLIstByEmpCode @EmpCode", new SqlParameter("@EmpCode", EmployeeCode));

                foreach (Menu ParrentMenu in ParentMenuList)
                {
                    UserMenuDto userMenuDto = new UserMenuDto();
                    userMenuDto.ParentMenu = ParrentMenu;

                    foreach (Menu menu in UserAccessMenuList)
                    {
                        if (userMenuDto.ParentMenu.ID == menu.ParentMenuID)
                        {
                            userMenuDto.ChildMenuList.Add(menu);
                        }
                    }

                    userMenuDto.ChildMenuList = userMenuDto.ChildMenuList.OrderBy(c => c.DisplayOrder).ToList();

                    MenuList.Add(userMenuDto);
                }

                MenuList = MenuList.OrderBy(m => m.ParentMenu.DisplayOrder).ToList();

                return MenuList;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Menu saveUpdateMenu(Menu menu)
        {
            try
            {
                Menu existMenu = new SysManageGenericRepository<Menu>().Find(u => u.ID == menu.ID).FirstOrDefault();

                //Update the menu
                if (existMenu != null)
                {
                    existMenu.ApplicationID = menu.ApplicationID;
                    existMenu.ParentMenuID = menu.ParentMenuID;
                    existMenu.MenuNameEng = menu.MenuNameEng;
                    existMenu.DisplayOrder = menu.DisplayOrder;
                    existMenu.MenuURL = menu.MenuURL;
                    existMenu.IsActive = menu.IsActive;
                    existMenu.UpdatedBy = menu.UpdatedBy;
                    existMenu.UpdatedOn = DateTime.Now;

                    return new SysManageGenericRepository<Menu>().Update(existMenu, u => u.ID == existMenu.ID);
                }
                //insert menu
                else
                {
                    menu.CreatedOn = DateTime.Now;
                    return new SysManageGenericRepository<Menu>().Insert(menu);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }
    }
}