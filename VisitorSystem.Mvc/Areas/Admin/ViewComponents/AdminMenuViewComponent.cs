using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Mvc.Areas.Admin.Models;

namespace VisitorSystem.Mvc.Areas.Admin.ViewComponents
{
    public class AdminMenuViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;
        public AdminMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;

        }
        public ViewViewComponentResult Invoke()
        {
            //Login olan kullanıcı bilgileri
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var roles = _userManager.GetRolesAsync(user).Result;
            return View(new UserWithRolesViewModel()
            {
                User = user,
                Roles = roles
            });


        }
    }
}
