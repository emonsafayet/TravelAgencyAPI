using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using MIS.BusinessService.SysService;
using MIS.Dto.userDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MIS.APIMVC.AuthProvider
{
    public class ServerAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private readonly int MAX_TIMEOUT_SECONDS = 900000;
        private UserService service = new UserService();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //return base.ValidateClientAuthentication(context);
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            UserDetail userDetail = service.ValidateUserLogin(context.UserName, context.Password);
            if (userDetail == null)
            {
                context.SetError("Invalid UserName or password.");
                return;
            }

            ClaimsIdentity oAuthIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);
            ClaimsIdentity cookiesIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(userDetail);
            AuthenticationTicket ticket =
            new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string,
            string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            if (context.TokenIssued)
            {
                context.Properties.ExpiresUtc = DateTimeOffset.Now.AddSeconds(MAX_TIMEOUT_SECONDS);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri
     (OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(UserDetail user)
        {
            // new UserAccountService().updateLogDetails(new ClientDetails { IPAddress = ClientIP, UserID = user.UserId.GetValueOrDefault() });

            string ID = "", ApplicationID = "", EmployeeCode = "", UserName = "", RoleID = "", RoleName = "", FullName = "",
                FName = "", MName = "", LName = "", FatherName = "", MotherName = "",
                Mobile = "", DOB = "", BloodGroup = "", Religion = "", Sex = "",
                MaritalStatus = "", Telephone = "", PresentAddress = "", PermanentAddress = "", NationalIDNo = "",
                 Nationality = "", EPersonName = "", EPersonAddress = "", EPersonTelephone = "", EmployeeStatus = "",
                 Department = "", Designation = "", DepartmentID = "", DesignationID = "", EmployeeLocationID = "", EmployeeLocation = "",
                 EmployeeTypeID = "", EmployeeType = "",
                 DOJ = "", DOS = "", ConfirmationDate = "";

            if (user.ID != null) ID = user.ID.ToString();
            if (user.ApplicationID != null) ApplicationID = user.ApplicationID.ToString();
            if (user.EmployeeCode != null) EmployeeCode = user.EmployeeCode;
            if (user.UserName != null) UserName = user.UserName;
            if (user.Mobile != null) Mobile = user.Mobile;
            if (user.RoleName != null) RoleName = user.RoleName;
            if (user.DepartmentID != null) DepartmentID = user.DepartmentID.ToString();
            if (user.DesignationID != null) DesignationID = user.DesignationID.ToString();
            if (user.EmployeeLocationID != null) EmployeeLocationID = user.EmployeeLocationID.ToString();
            if (user.EmployeeLocation != null) EmployeeLocation = user.EmployeeLocation.ToString();
            if (user.EmployeeType != null) EmployeeType = user.EmployeeType;
            if (user.EmployeeTypeID != null) EmployeeTypeID = user.EmployeeTypeID.ToString();

            if (user.RoleID != null) RoleID = user.RoleID.ToString();
            if (user.FullName != null) FullName = user.FullName;
            if (user.FName != null) FName = user.FName;
            if (user.MName != null) MName = user.MName;
            if (user.LName != null) LName = user.LName;
            if (user.FatherName != null) FatherName = user.FatherName;
            if (user.MotherName != null) MotherName = user.MotherName;
            if (user.Department != null) Department = user.Department;
            if (user.Designation != null) Designation = user.Designation;
            if (user.DOB != null) DOB = user.DOB.ToString();
            if (user.BloodGroup != null) BloodGroup = user.BloodGroup;
            if (user.Religion != null) Religion = user.Religion;
            if (user.Sex != null) Sex = user.Sex;
            if (user.MaritalStatus != null) MaritalStatus = user.MaritalStatus;
            if (user.Telephone != null) Telephone = user.Telephone.ToString();
            if (user.PresentAddress != null) PresentAddress = user.PresentAddress;
            if (user.PermanentAddress != null) PermanentAddress = user.PermanentAddress;
            if (user.NationalIDNo != null) NationalIDNo = user.NationalIDNo.ToString();
            if (user.Nationality != null) Nationality = user.Nationality.ToString();
            if (user.EPersonName != null) EPersonName = user.EPersonName.ToString();
            if (user.EPersonAddress != null) EPersonAddress = user.EPersonAddress;
            if (user.EPersonTelephone != null) EPersonTelephone = user.EPersonTelephone;
            if (user.EmployeeStatus != null) EmployeeStatus = user.EmployeeStatus;
            if (user.DOJ != null) DOJ = user.DOJ.ToString();
            if (user.DOS != null) DOS = user.DOS.ToString();
            if (user.ConfirmationDate != null) ConfirmationDate = user.ConfirmationDate.ToString();
            IDictionary<string, string>
            data = new Dictionary<string, string>
            {
                { "ID", ID },
                { "ApplicationID", ApplicationID },
                { "Mobile", Mobile},
                { "RoleName", RoleName},

                { "DepartmentID", DepartmentID},
                { "DesignationID", DesignationID},
                { "EmployeeLocationID", EmployeeLocationID},
                { "EmployeeLocation", EmployeeLocation},
                { "EmployeeTypeID", EmployeeTypeID},
                { "EmployeeType", EmployeeType},

                { "EmployeeCode", EmployeeCode },
                { "UserName", UserName },
                { "RoleID", RoleID},
                { "FullName", FullName},
                { "FName", FName },
                { "MName", MName },
                { "LName", LName },
                { "FatherName", FatherName},
                { "MotherName", MotherName},
                { "Department", Department},
                { "Designation", Designation},
                { "DOB", DOB},
                { "BloodGroup", BloodGroup},
                { "Religion", Religion},
                { "Sex", Sex},
                { "MaritalStatus", MaritalStatus},
                { "PresentAddress", PresentAddress},
                { "PermanentAddress", PermanentAddress},
                { "NationalIDNo", NationalIDNo},
                { "EPersonName", EPersonName},
                { "EPersonAddress", EPersonAddress},
                { "EPersonTelephone", EPersonTelephone},
                { "EmployeeStatus", EmployeeStatus},
                { "DOJ", DOJ},
                { "DOS", DOS},
                { "ConfirmationDate", ConfirmationDate},
            };
            return new AuthenticationProperties(data);
        }
    }
}