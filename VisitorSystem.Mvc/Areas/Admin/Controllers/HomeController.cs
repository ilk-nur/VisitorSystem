using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSystem.Services.Abstract;

namespace VisitorSystem.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IVisitorService _visitorService;
        public HomeController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
                
        }

        public async Task<IActionResult> Index()
        {
            var getallcount = await _visitorService.GetAllCount();
            var getallNotIsExit = await _visitorService.GetNotIsExit();
            var getallIsExit = await _visitorService.GetIsExit();

            ViewBag.GetAllCount = getallcount.Data;
            ViewBag.GetAllNotIsExit = getallNotIsExit.Data;
            ViewBag.GetAllIsExit = getallIsExit.Data;

            return View();
        }
    }
}
