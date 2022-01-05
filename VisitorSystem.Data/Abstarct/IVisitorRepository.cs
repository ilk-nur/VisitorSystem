using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Shared.Data.Abstract;

namespace VisitorSystem.Data.Abstarct
{
    public  interface IVisitorRepository:IEntityRepository<Visitor>
    {

    }
}
