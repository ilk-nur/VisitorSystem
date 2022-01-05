using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSystem.Entities.Dtos.DepartmentDto;
using VisitorSystem.Entities.Dtos.UserDto;

namespace VisitorSystem.Mvc.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
        //Doldurulmuş yerlerin ve hataların geriye dönmesi için
        public UserUpdateDto UserUpdateDto { get; set; }
        //Eger validate doğru değilse partial döndürür.
        public string UserUpdatePartial { get; set; }
        //Eklendikten sonra geri döner.
        public UserDto UserDto { get; set; }
    }
}
