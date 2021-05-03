using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.userDto
{
    public class UserDetail
    {
        public Nullable<int> ID { get; set; }

        public Nullable<int> ApplicationID { get; set; }
        public string EmployeeCode { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public Nullable<int> RoleID { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> EmployeeLocationID { get; set; }
        public Nullable<int> EmployeeTypeID { get; set; }
        public string FullName { get; set; }

        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }

        public Nullable<DateTime> DOB { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string Sex { get; set; }

        public string MaritalStatus { get; set; }
        public string Telephone { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string NationalIDNo { get; set; }

        public string Nationality { get; set; }
        public string EPersonName { get; set; }
        public string EPersonAddress { get; set; }
        public string EPersonTelephone { get; set; }
        public Nullable<int> EmployeeStatusID { get; set; }

        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public Nullable<DateTime> DOS { get; set; }
        public Nullable<DateTime> ConfirmationDate { get; set; }

        public string Remarks { get; set; }
        public string RoleName { get; set; }
        public string ApplicationName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }

        public string EmployeeLocation { get; set; }
        public string EmployeeType { get; set; }

        public Nullable<Boolean> UserIsActive { get; set; }
        public string EmployeeStatus { get; set; }

    }
}