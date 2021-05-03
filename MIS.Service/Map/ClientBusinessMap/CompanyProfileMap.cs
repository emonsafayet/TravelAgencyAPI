using AutoMapper;
using MIS.Data.SysModels;
using MIS.Dto.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.Map.ClientBusinessMap
{
    public class CompanyProfileMap
    {
        public CompanyProfile map(CompanyProfileDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompanyProfileDTO, CompanyProfile>();
            });

            return config.CreateMapper().Map<CompanyProfileDTO, CompanyProfile>(source);
        }
    }
}
