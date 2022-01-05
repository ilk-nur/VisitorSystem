using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.Entities.Dtos.UserDto
{
     public class UserLoginDto
    {
        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} boş geçilememelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olamamalıdır")]
        [MinLength(10, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş geçilememelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olamamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla?")]
        public bool RememberMe { get; set; }
    }
}
