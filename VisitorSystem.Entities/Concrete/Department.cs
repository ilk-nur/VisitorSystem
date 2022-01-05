using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Shared.Entities.Abstract;

namespace VisitorSystem.Entities.Concrete
{
     public class Department:EntityBase,IEntity
    {
        public string Name { get; set; }
        public  long  CountactNo { get; set; }
        public ICollection<Visitor> Visitors { get; set; }

    }
}
