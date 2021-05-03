using AutoMapper;
using MIS.Data.ClientModel;
using MIS.Dto.TransactionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.Map.TransactionMap
{
    public class HolidayPackageTourMasterMap
    {
        public HolidayPackageMaster map(HolidayPackageTourMasterDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HolidayPackageTourMasterDTO, HolidayPackageMaster>();
            });

            return config.CreateMapper().Map<HolidayPackageTourMasterDTO, HolidayPackageMaster>(source);
        }
        public HolidayPackageTourMasterDTO DtoMap(HolidayPackageMaster source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HolidayPackageMaster, HolidayPackageTourMasterDTO>();
            });

            return config.CreateMapper().Map<HolidayPackageMaster, HolidayPackageTourMasterDTO>(source);
        }
    }
}
