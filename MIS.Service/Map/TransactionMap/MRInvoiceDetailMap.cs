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
    public class MRInvoiceDetailMap
    {
        public MRInvoiceDetail map(MRInvoiceDetailDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MRInvoiceDetailDTO, MRInvoiceDetail>();
            });

            return config.CreateMapper().Map<MRInvoiceDetailDTO, MRInvoiceDetail>(source);
        }
    }
}
