using AutoMapper;
using MIS.Data.ClientModel;
using MIS.Dto.BusinessDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.Map.ClientBusinessMap
{
    public class PackageDetailMap
    {
        public PackageDetail map(PackageDetailDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PackageDetailDTO, PackageDetail>();
            });

            return config.CreateMapper().Map<PackageDetailDTO, PackageDetail>(source);
        }
    }
}
