using MIS.Data.ClientModel;
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
    public class BusinessManageGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext context = null;
        private DbSet<T> table = null;

        public BusinessManageGenericRepository()
        {
            try
            {
                this.context = new ClientBusinessEntities();
                this.context.Configuration.LazyLoadingEnabled = false;
                this.table = context.Set<T>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                T existing = table.FirstOrDefault(predicate);
                table.Remove(existing);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       

        // READ
        public List<T> Find(Expression<Func<T, bool>> predicate)
        {

            try
            {
                return table.Where(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return table.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // STORED PROCESDURE
        public List<T> FindUsingSP(string query, params object[] parameters)
        {
            try
            {
                return context.Database.SqlQuery<T>(query, parameters).ToList<T>();
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        public T FindOneUsingSP(string query, params object[] parameters)
        {
            try
            {
                return context.Database.SqlQuery<T>(query, parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // INSERT
        public T Insert(T Entity)
        {
            try
            {
                table.Add(Entity);
                context.SaveChanges();
                return Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // UPDATE
        public T Update(T Entity, Expression<Func<T, bool>> predicate)
        {
            try
            {
                var originalValues = FindOne(predicate);
                context.Entry(originalValues).CurrentValues.SetValues(Entity);
                context.SaveChanges();
                return originalValues;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ExecuteCommand(string query, params object[] parameters)
        {
            try
            {
                context.Database.ExecuteSqlCommand(query, parameters);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 

        public List<T> GetAll()
        {
            try
            {
                return table.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet getMultipleDataSetUsingSP(string StoreProcedure, List<SqlParameter> parameterList)
        {
            try
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
            catch (Exception ex)
            {

                throw ex;
            }
        }



        // COMMIT CHANGES

        //public Boolean saveChanges()
        //{
        //    this.context.SaveChanges();
        //    return true;
        //}

        //public Boolean commit()
        //{
        //    this.transaction.Commit();
        //    this.transaction = this.context.Database.BeginTransaction();
        //    return true;  
        //}

        //public Boolean rollback()
        //{
        //    this.transaction.Rollback();
        //    return true;
        //}


    }
}