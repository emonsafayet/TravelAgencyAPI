using MIS.Data.Repositories;
using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.SysService
{
    public class SettingsService
    {
        public Exception Error = new Exception();
        private SysManageEntities context = new SysManageEntities();

        public signature saveUpdateSignature(signature signature)
        {
            try
            {
                if (signature.ColumnName == null || signature.ColumnName == "") throw new Exception("Column  is empty.");
                //Update
                if (signature != null && signature.ID > 0)
                {
                    signature.UpdatedOn = DateTime.Now;

                    return new SysManageGenericRepository<signature>().Update(signature, r => r.ID == signature.ID);
                }
                //Insert 
                else
                {
                    signature.CreatedOn = DateTime.Now;

                    return new SysManageGenericRepository<signature>().Insert(signature);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // GET

        public List<signature> getSignatureList()
        {
            try
            {
                return new SysManageGenericRepository<signature>().GetAll().OrderByDescending(r => r.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        // GET

        public List<TableType> getTableTypeList()
        {
            try
            {
                return new SysManageGenericRepository<TableType>().GetAll().OrderByDescending(r => r.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }
         

        
    }
}
