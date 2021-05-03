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
    public class VisaRegistrationMap
    {
        public VisaMaster map(VisaRegistationDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VisaRegistationDTO, VisaMaster>();
            });

            return config.CreateMapper().Map<VisaRegistationDTO, VisaMaster>(source);
        }
    }
}
