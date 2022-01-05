using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Data.Abstarct;
using VisitorSystem.Data.Concrete.EntityFramework.Contexts;
using VisitorSystem.Data.Concrete.EntityFramework.Repositories;

namespace VisitorSystem.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VisitorSystemContext _context;

        private  EfVisitorRepository _visitorRepository;
       
        private  EfDepartmentRepository _departmentRepository;

        public UnitOfWork(VisitorSystemContext context)
        {
            _context = context;

        }



        public IVisitorRepository Visitors => _visitorRepository ?? new EfVisitorRepository(_context);

       

        public IDepartmentRepository Departments => _departmentRepository ?? new EfDepartmentRepository(_context);

       

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

       
    }
}
