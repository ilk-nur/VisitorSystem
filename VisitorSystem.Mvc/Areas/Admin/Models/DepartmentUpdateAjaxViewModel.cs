using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSystem.Entities.Dtos.DepartmentDto;

namespace VisitorSystem.Mvc.Areas.Admin.Models
{
    public class DepartmentUpdateAjaxViewModel
    {
        public DepartmentUpdateDto DepartmentUpdateDto { get; set; }
        //Eger validate doğru değilse partial döndürür.
        public string DepartmentUpdatePartial { get; set; }
        //Eklendikten sonra geri döner.
        public DepartmentDto DepartmentDto { get; set; }
    }
}
