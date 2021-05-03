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
    public class MRMasterMap
    { 
        public MRMaster map(MoneyReceiptDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MoneyReceiptDTO, MRMaster>();
            });

            return config.CreateMapper().Map<MoneyReceiptDTO, MRMaster>(source);
        }
    }
}
