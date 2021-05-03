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
    public class GroupTourMasterMap
    {
        public GroupTourMaster map(GrouptourMasterDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GrouptourMasterDTO, GroupTourMaster>();
            });

            return config.CreateMapper().Map<GrouptourMasterDTO, GroupTourMaster>(source);
        }
    }
}
