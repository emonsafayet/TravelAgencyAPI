using LPLERP.Common;
using MIS.Data.Repositories;
using MIS.Data.SysModels;
using MIS.Dto.userDto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = MIS.Data.SysModels.UserTbl;

namespace MIS.BusinessService.SysService
{
    public class UserService
    {
        public Exception Error = new Exception();

        public UserTbl userSaveUpdate(UserTbl userTbl)
        {
            try
            {
                UserTbl ExistUser = new SysManageGenericRepository<UserTbl>().Find(u => u.UserName == userTbl.UserName).FirstOrDefault();
                //Update the user
                if (ExistUser != null)
                {
                    ExistUser.ApplicationID = userTbl.ApplicationID;
                    ExistUser.IsActive = userTbl.IsActive;
                    ExistUser.RoleID = userTbl.RoleID;
                    ExistUser.UpdatedBy = userTbl.UpdatedBy;
                    ExistUser.UpdatedOn = DateTime.Now;
                    ExistUser.UserPassword = new Encryption().EncryptWord(userTbl.UserPassword);
                    return new SysManageGenericRepository<User>().Update(ExistUser, u => u.ID == ExistUser.ID);
                }
                //insert new user
                else
                {
                    userTbl.CreatedOn = DateTime.Now;
                    userTbl.UserPassword = new Encryption().EncryptWord(userTbl.UserPassword);
                    return new SysManageGenericRepository<User>().Insert(userTbl);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<User> getUserList()
        {
            try
            {
                return new SysManageGenericRepository<User>().GetAll().OrderByDescending(u => u.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<UserDetail> getUserDetailList()
        {
            try
            {
                return new SysManageGenericRepository<UserDetail>().FindUsingSP("getUserDetailList");
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //User Access Type List
        public List<UserAccessType> getUserAccessTypeList()
        {
            try
            {
                return new SysManageGenericRepository<UserAccessType>().GetAll().OrderByDescending(i => i.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public UserAccessType userSaveUpdateAccessType(UserAccessType UserAccessType)
        {
            try
            {
                //Update the user Acccess Type
                if (UserAccessType.ID > 0)
                {
                    UserAccessType ExistUserAccessType = new SysManageGenericRepository<UserAccessType>().Find(u => u.ID == UserAccessType.ID).FirstOrDefault();

                    ExistUserAccessType.IsActive = UserAccessType.IsActive;
                    ExistUserAccessType.PermissionName = UserAccessType.PermissionName;
                    ExistUserAccessType.UpdatedBy = UserAccessType.UpdatedBy;
                    ExistUserAccessType.UpdatedOn = DateTime.Now;
                    return new SysManageGenericRepository<UserAccessType>().Update(ExistUserAccessType, u => u.ID == ExistUserAccessType.ID);
                }
                //insert new user Acccess Type
                else
                {
                    UserAccessType.CreatedOn = DateTime.Now;

                    return new SysManageGenericRepository<UserAccessType>().Insert(UserAccessType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //for AUTHENTICATION API
        public UserDetail ValidateUserLogin(string userName, string UserPassword)
        {
            try
            {
                var encryptedPass = new Encryption().EncryptWord(UserPassword);
                UserTbl result = new SysManageGenericRepository<User>().Find(t => (t.UserName == userName || t.EmployeeCode == userName) && t.UserPassword == encryptedPass).FirstOrDefault();

                if (result != null && result.UserName != null)
                {
                    UserDetail s = new SysManageGenericRepository<UserDetail>().FindOneUsingSP("getUserDetailByUsername @UserName", new SqlParameter("@UserName", userName));
                    return s;
                }
                else
                {
                    throw new Exception("Username and Password Not Found.");
                }
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public UserDetail GetUserDetail(string userName)
        {
            try
            {
                UserDetail result = new SysManageGenericRepository<UserDetail>().FindOneUsingSP("getUserDetailByUsername @UserName", new SqlParameter("@UserName", userName));

                if (result != null && result.EmployeeCode != null)
                {
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public APIRequestLog saveApiLog(APIRequestLog apiLog)
        {
            try
            {
                return new SysManageGenericRepository<APIRequestLog>().Insert(apiLog);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public ErrorLog saveErrorLog(ErrorLog Log)
        {
            try
            {
                return new SysManageGenericRepository<ErrorLog>().Insert(Log);
            }
            catch (Exception ex) { Error = ex; return null; }
        }
    }
}