using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Shared.Entities.Abstract;

namespace VisitorSystem.Entities.Dtos.VisitorDto
{
    public class VisitorListDto:DtoGetBase
    {
        public IList<Visitor> Visitors { get; set; }
    }
}
