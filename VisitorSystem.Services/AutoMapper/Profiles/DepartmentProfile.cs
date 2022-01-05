using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;

using VisitorSystem.Entities.Dtos.DepartmentDto;

namespace VisitorSystem.Services.AutoMapper.Profiles
{
    public  class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            //ÖNCE KAYNAK SONRA GİDİCEĞİ YER
            CreateMap<DepartmentAddDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Department, DepartmentUpdateDto>();
        }
    }
}
