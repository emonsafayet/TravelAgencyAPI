using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MIS.Data.ClientModel;
using MIS.Dto.TransactionDTO;

namespace MIS.BusinessService.Map.TransactionMap
{
    public class HolidayPackageTourDetailMap
    {
        public HolidayPackageDetail map(HolidayPackageTourDetailDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HolidayPackageTourDetailDTO, HolidayPackageDetail>();
            });

            return config.CreateMapper().Map<HolidayPackageTourDetailDTO, HolidayPackageDetail>(source);
        }
    }
}
