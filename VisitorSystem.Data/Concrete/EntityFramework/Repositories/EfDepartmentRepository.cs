using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Data.Abstarct;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Shared.Data.Concrete.EntityFramework;

namespace VisitorSystem.Data.Concrete.EntityFramework.Repositories
{
    public class EfDepartmentRepository:EfEntityRepositoryBase<Department>,IDepartmentRepository
    {
        public EfDepartmentRepository(DbContext dbContext):base(dbContext)
        {

        }
    }
}
