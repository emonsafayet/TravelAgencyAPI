using MIS.Data.Repositories;
using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.SysService
{
    public static class LogService
    {
        public static List<BrowsingLog> GetBrowsingLogList()
        {
            try
            {
                return new SysManageGenericRepository<BrowsingLog>().GetAll().ToList();
            }
            catch (Exception ex) { return null; }
        }

        public static bool saveBrowsingLog(string url, string user)
        {
            try
            {
                BrowsingLog log = new BrowsingLog();
                log = new SysManageGenericRepository<BrowsingLog>().Insert(log);
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}