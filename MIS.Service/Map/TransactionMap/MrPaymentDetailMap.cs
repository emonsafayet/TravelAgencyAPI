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
    public class MrPaymentDetailMap
    {
        public MRPaymentDetails map(MRPaymentDetailsDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MRPaymentDetailsDTO, MRPaymentDetails>();
            });

            return config.CreateMapper().Map<MRPaymentDetailsDTO, MRPaymentDetails>(source);
        }
    }
}
