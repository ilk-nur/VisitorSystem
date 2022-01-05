using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSystem.Entities.Dtos.RoleDto;

namespace VisitorSystem.Mvc.Areas.Admin.Models
{
    public class RoleAddAjaxViewModel
    {
        public RoleAddDto RoleAddDto { get; set; }
        //Eger validate doğru değilse partial döndürür.
        public string RoleAddPartial { get; set; }
        //Eklendikten sonra geri döner.
        public RoleDto RoleDto { get; set; }
    }
}
