using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Shared.Entities.Abstract;

namespace VisitorSystem.Entities.Dtos.UserDto
{
    public  class UserListDto:DtoGetBase
    {

        public IList<User> Users { get; set; }
    }
}
