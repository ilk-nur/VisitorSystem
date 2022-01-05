using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Shared.Entities.Abstract;

namespace VisitorSystem.Entities.Concrete
{
    public class User:IdentityUser<int>
    {
           
              
        public string Picture { get; set; }
        public ICollection<Visitor> Visitors { get; set; }
    }
}
