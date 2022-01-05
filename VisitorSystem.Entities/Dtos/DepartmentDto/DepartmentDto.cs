using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Shared.Entities.Abstract;
using VisitorSystem.Entities.Concrete;

namespace VisitorSystem.Entities.Dtos.DepartmentDto
{
    public class DepartmentDto:DtoGetBase
    {
        public Department Department { get; set; }
    }
}
