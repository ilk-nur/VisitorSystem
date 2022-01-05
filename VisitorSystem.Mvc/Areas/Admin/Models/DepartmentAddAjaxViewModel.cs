using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSystem.Entities.Dtos.DepartmentDto;

namespace VisitorSystem.Mvc.Areas.Admin.Models
{
    public class DepartmentAddAjaxViewModel
    {
        public DepartmentAddDto DepartmentAddDto { get; set; }
        //Eger validate doğru değilse partial döndürür.
        public string DepartmentAddPartial { get; set; }
        //Eklendikten sonra geri döner.
        public DepartmentDto DepartmentDto { get; set; }
    }
}
