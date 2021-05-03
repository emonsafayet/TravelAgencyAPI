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
    public class HotelBookingMasterMap
    {
        public HotelBookMaster map(HotelBookingDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotelBookingDTO, HotelBookMaster>();
            });

            return config.CreateMapper().Map<HotelBookingDTO, HotelBookMaster>(source);
        }
    } 
}
