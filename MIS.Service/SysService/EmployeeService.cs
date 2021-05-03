using MIS.Data.Repositories;
using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.SysService
{

    public class EmployeeService
    {
        public Exception Error = new Exception();
        private SysManageEntities context = new SysManageEntities();

        //Post

        public Employee saveUpdateEmployee(Employee employee)
        {
            try
            {
                if (employee.FullName == null || employee.FullName == "") throw new Exception("Role Name is empty.");

                if (employee != null && employee.ID > 0)
                {
                    if (employee.MName == null)
                        employee.FullName = employee.FName + ' ' + employee.LName;
                    else
                        employee.FullName = employee.FName + ' ' + employee.MName + ' ' + employee.LName;
                    employee.UpdatedOn = DateTime.Now;
                    return new SysManageGenericRepository<Employee>().Update(employee, r => r.ID == employee.ID);
                }
                //Insert
                else
                {
                    employee.EmployeeCode = GenerateEmployeeCode();
                    if (employee.MName == null)
                        employee.FullName = employee.FName + ' ' + employee.LName;
                    else
                        employee.FullName = employee.FName + ' ' + employee.MName + ' ' + employee.LName;
                    employee.CreatedOn = DateTime.Now;
                    return new SysManageGenericRepository<Employee>().Insert(employee);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //Gert Employee List
        public List<Employee> getEmployeeList()
        {
            try
            {
                return new SysManageGenericRepository<Employee>().GetAll().OrderByDescending(u => u.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //Designation
        //Get Designation
        public List<EmployeeDesignation> getDesignationList()
        {
            try
            {
                return new SysManageGenericRepository<EmployeeDesignation>().GetAll().OrderByDescending(u => u.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public EmployeeDesignation saveUpdateDesignation(EmployeeDesignation designation)
        {
            try
            {
                if (designation.DesignationName == null || designation.DesignationName == "") throw new Exception("Designation Name is empty.");

                if (designation != null && designation.ID > 0)
                {
                    designation.UpdatedOn = DateTime.Now;

                    return new SysManageGenericRepository<EmployeeDesignation>().Update(designation, r => r.ID == designation.ID);
                }
                else
                {
                    designation.CreatedOn = DateTime.Now;

                    return new SysManageGenericRepository<EmployeeDesignation>().Insert(designation);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //Get Department
        public List<EmployeeDepartment> getDepartmentList()
        {
            try
            {
                return new SysManageGenericRepository<EmployeeDepartment>().GetAll().OrderByDescending(u => u.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //Get Location
        public List<EmployeeLocation> getLocationList()
        {
            try
            {
                return new SysManageGenericRepository<EmployeeLocation>().GetAll().OrderByDescending(u => u.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //Get Employee Status
        public List<EmployeeStatusTbl> getEmployeeStatusList()
        {
            try
            {
                return new SysManageGenericRepository<EmployeeStatusTbl>().GetAll().OrderByDescending(u => u.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //Get Employee Type
        public List<EmployeeType> getEmployeeTypeList()
        {
            try
            {
                return new SysManageGenericRepository<EmployeeType>().GetAll().OrderByDescending(u => u.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //Employee List With Out User Account For User Menu
        public List<Employee> GetEmployeeListWithOutUserAccount()
        {
            try
            {
                return new SysManageGenericRepository<Employee>().FindUsingSP("getEmployeeListWhoHaveNoAccount");
            }
            catch (Exception ex) { Error = ex; return null; }

        }

        //Generate Employee Code

        private string GenerateEmployeeCode()
        {
            string employeeCode = "";

            try
            {
                var lastEmployee = new SysManageGenericRepository<Employee>().GetAll().OrderByDescending(u => u.ID).FirstOrDefault();

                //ex: EMP0002

                if (lastEmployee == null)
                    employeeCode = "EMP0001";
                else
                {
                    int count = Convert.ToInt32(lastEmployee.EmployeeCode.Remove(0, 3)) + 1;

                    if (count.ToString().Length == 1) employeeCode = "000" + count.ToString();
                    else if (count.ToString().Length == 2) employeeCode = "00" + count.ToString();
                    else if (count.ToString().Length == 3) employeeCode = "0" + count.ToString();
                    else employeeCode = count.ToString();

                    employeeCode = "EMP" + employeeCode;
                }
            }
            catch (Exception ex) { Error = ex; return null; }


            return employeeCode;
        }

    }
}
