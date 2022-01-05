using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Entities.Dtos.RoleDto;

namespace VisitorSystem.Services.AutoMapper.Profiles
{  
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleAddDto, Role>();
           
        }
    }
}
