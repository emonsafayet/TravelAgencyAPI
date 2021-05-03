using AutoMapper;
using MIS.Data.ClientModel;
using MIS.Dto.BusinessDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.Map.TransactionMap
{
    public class OnlineRegMasterMap
    {
        public OnlineRegMaster map(OnlineRegistationDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OnlineRegistationDTO, OnlineRegMaster>();
            });

            return config.CreateMapper().Map<OnlineRegistationDTO, OnlineRegMaster>(source);
        }
    }
}
