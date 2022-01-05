using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.Data.Abstarct
{
     public interface IUnitOfWork: IAsyncDisposable
    {
        IVisitorRepository Visitors { get; }
      
        IDepartmentRepository Departments { get; }
        //int etkilenen kayıt sayısını almak isteyebiliriz.
        Task<int> SaveAsync();

    }
}
