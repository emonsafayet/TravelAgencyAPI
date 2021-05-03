using AutoMapper;
using MIS.Data.SysModels;
using MIS.Dto.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.Map
{
    // MAPPING 

    public class RoleMap
    {
        public Role map(RoleDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoleDto, Role>();
            });

            return config.CreateMapper().Map<RoleDto, Role>(source);
        }
    }
}
