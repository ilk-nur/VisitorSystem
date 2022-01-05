using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Shared.Entities.Abstract;

namespace VisitorSystem.Entities.Dtos.RoleDto
{
     public class RoleAddDto:DtoGetBase
    {

        [DisplayName("Yetki Adı")]
        [Required(ErrorMessage = "{0} boş geçilememelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olamamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string Name { get; set; }

       
    }
}
