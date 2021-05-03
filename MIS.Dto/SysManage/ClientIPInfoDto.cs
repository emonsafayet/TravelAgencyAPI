using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.SysManage
{
    public class ClientIPInfoDto
    {
        public string city { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string isp { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string org { get; set; }
        public string query { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string status { get; set; }
        public string timezone { get; set; }
        public string zip { get; set; }

        public ClientDeviceInfoDto ClientDeviceInfoDto = new ClientDeviceInfoDto();
    }

    public class ClientDeviceInfoDto
    {
        public string browser { get; set; }
        public string browser_version { get; set; }
        public string device { get; set; }
        public string deviceType { get; set; }
        public string orientation { get; set; }
        public string os { get; set; }
        public string os_version { get; set; }
        public string userAgent { get; set; }
    }

    public class IpInfoDto
    {
        public string EmployeeCode { get; set; }
        public string UserName { get; set; }
        public string routePath { get; set; }
        public string IpAddressDetails { get; set; }
    }
}