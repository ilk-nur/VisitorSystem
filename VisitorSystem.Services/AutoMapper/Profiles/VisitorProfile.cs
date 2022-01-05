using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Entities.Dtos.VisitorDto;

namespace VisitorSystem.Services.AutoMapper.Profiles
{
    public  class VisitorProfile:Profile
    {

        public VisitorProfile()
        {
            CreateMap<VisitorAddDto, Visitor>();
          
        }
    }
}
