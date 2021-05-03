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
    public class AirTicketMap
    {
        public AirTicketMaster map(AirTicketRegMasterDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AirTicketRegMasterDTO, AirTicketMaster>();
            });

            return config.CreateMapper().Map<AirTicketRegMasterDTO, AirTicketMaster>(source);
        } 
    }
}