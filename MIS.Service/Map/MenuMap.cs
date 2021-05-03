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
    public class MenuMap
    {
        public MenuModel MenuToMenuDtoMap(Menu source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Menu, MenuModel>();
            });

            return config.CreateMapper().Map<Menu, MenuModel>(source);
        }
    }
}