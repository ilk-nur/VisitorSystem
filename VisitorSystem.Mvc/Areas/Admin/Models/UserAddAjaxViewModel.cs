using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSystem.Entities.Dtos.DepartmentDto;
using VisitorSystem.Entities.Dtos.UserDto;

namespace VisitorSystem.Mvc.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        //Doldurulmuş yerlerin ve hataların geriye dönmesi için
        public UserAddDto UserAddDto { get; set; }
        //Eger validate doğru değilse partial döndürür.
        public string UserAddPartial { get; set; }
        //Eklendikten sonra geri döner.
        public UserDto UserDto { get; set; }
    }
}
