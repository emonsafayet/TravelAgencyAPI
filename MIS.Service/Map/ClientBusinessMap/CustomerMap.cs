using AutoMapper;
using MIS.Data.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.Map.ClientBusinessMap
{
    public class CustomerMap
    {
        public Customer map(CustomerDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>();
            });

            return config.CreateMapper().Map<CustomerDto, Customer>(source);
        }

    }     
}
