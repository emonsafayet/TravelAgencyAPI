using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MIS.Data.ClientModel;
using MIS.Dto.BusinessDTO;

namespace MIS.BusinessService.Map.ClientBusinessMap
{
   public class PackageMasterMap
    {
        public PackageMaster map(PackageMasterDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PackageMasterDTO, PackageMaster>();
            });

            return config.CreateMapper().Map<PackageMasterDTO, PackageMaster>(source);
        }

        public PackageMasterDTO DtoMap(PackageMaster source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PackageMaster,PackageMasterDTO>();
            });

            return config.CreateMapper().Map<PackageMaster, PackageMasterDTO>(source);
        }
    }
}
