using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSystem.Entities.Dtos.VisitorDto;

namespace VisitorSystem.Mvc.Areas.Admin.Models
{
    public class VisitorAddAjaxViewModel
    {
        public VisitorAddDto VisitorAddDto { get; set; }
        //Eger validate doğru değilse partial döndürür.
        public string VisitorAddPartial { get; set; }
        //Eklendikten sonra geri döner.
        public VisitorDto VisitorDto { get; set; }

      
    }
}
