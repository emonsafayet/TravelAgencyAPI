using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Data.Repositories
{
    public class SysManageGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext context = null;
        private DbSet<T> table = null;

        public SysManageGenericRepository()
        {
            this.context = new SysManageEntities();
            this.context.Configuration.LazyLoadingEnabled = false;
            this.table = context.Set<T>();
        }

        // DELETE
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            T existing = table.Find(predicate);
            table.Remove(existing);
            context.SaveChanges();
        }

        // READ
        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return table.FirstOrDefault(predicate);
        }

        // STORED PROCESDURE
        public List<T> FindUsingSP(string query, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(query, parameters).ToList<T>();
        }

        public T FindOneUsingSP(string query, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(query, parameters).FirstOrDefault();
        }

        // INSERT
        public T Insert(T Entity)
        {
            table.Add(Entity);
            context.SaveChanges();
            return Entity;
        }

        // UPDATE
        public T Update(T Entity, Expression<Func<T, bool>> predicate)
        {
            var originalValues = FindOne(predicate);
            context.Entry(originalValues).CurrentValues.SetValues(Entity);
            context.SaveChanges();
            return originalValues;
        }

        public bool ExecuteCommand(string query, params object[] parameters)
        {
            context.Database.ExecuteSqlCommand(query, parameters);
            return true;
        } 

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public DataSet getMultipleDataSetUsingSP(string StoreProcedure, List<SqlParameter> parameterList)
        {
            SqlConnection con = new SqlConnection(this.context.Database.Connection.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand(StoreProcedure, con);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parameter in parameterList)
            {
                cmd.Parameters.Add(parameter);
            }
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            return ds;
        }
    }
}