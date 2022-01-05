using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Entities.Dtos.VisitorDto;
using VisitorSystem.Mvc.Areas.Admin.Models;
using VisitorSystem.Services.Abstract;
using VisitorSystem.Shared.Utilities.Extensions;
using VisitorSystem.Shared.Utilities.Results.ComplexTypes;

namespace VisitorSystem.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VisitorController : Controller
    {
        private readonly IVisitorService _visitorService;
        private readonly UserManager<User> _userManager;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        
        public VisitorController(IVisitorService visitorService, IDepartmentService departmentService,IMapper mapper, UserManager<User> userManager)
        {
            _visitorService = visitorService;
            _departmentService = departmentService;
            _mapper = mapper;
            _userManager = userManager;

        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var result = await _visitorService.GetAllNonDeleted();


            return View(result.Data);
        }
        





        [Authorize]
        public async Task<JsonResult> GetAllVisitor()
        {
            var result = await _visitorService.GetAllNonDeleted();

             var visitors = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve

            });
            return Json(visitors);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
           
            var result = await _departmentService.GetAllNonDeleted();
            if (result.ResultStatus == ResultStatus.Success)
            {

                return PartialView("_VisitorAddPartial", new VisitorAddDto()
                {
                    Departments = result.Data.Departments,
                    BirthDate=DateTime.Now


                });
            }
            return NotFound();
            
           
           
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(VisitorAddDto visitorAddDto)
        {

            if (ModelState.IsValid)
            {

                var visitor = _mapper.Map<Visitor>(visitorAddDto);
                var department = await _departmentService.Get(visitorAddDto.DepartmentId);
              
               
               
               
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var result = await _visitorService.Add(visitorAddDto, user.UserName);
                result.Data.Visitor.Department= department.Data.Department;
               

                var departments = await _departmentService.GetAllNonDeleted();
                
               
                if (result.ResultStatus == ResultStatus.Success)
                {

                    var visitorAddAjaxModel = JsonSerializer.Serialize(new VisitorAddAjaxViewModel()
                    {
                        VisitorDto = new VisitorDto()
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{visitorAddDto.FirstName} adındaki ziyaretçi, başarıyla eklenmiştir.",
                            Visitor = result.Data.Visitor,
                            

                        },
                        VisitorAddPartial = await this.RenderViewToStringAsync("_VisitorAddPartial", new VisitorAddDto()
                        {

                            Departments = departments.Data.Departments


                        })


                    }, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve

                    });
                    
                  
                    return Json(visitorAddAjaxModel);
                }
                else
                {
                    //foreach (var error in )
                    //{
                    //    ModelState.AddModelError("", error.Description);

                    //}
                    var visitorAddAjaxErrorModel = JsonSerializer.Serialize(new VisitorAddAjaxViewModel()
                    {
                        VisitorAddDto = visitorAddDto,
                        VisitorAddPartial = await this.RenderViewToStringAsync("_VisitorAddPartial", new VisitorAddDto()
                        {

                            Departments = departments.Data.Departments

                        })

                    }) ;
                    return Json(visitorAddAjaxErrorModel);
                }


            }
            else
            {
                var result = await _departmentService.GetAllNonDeleted();
                var visitorAddAjaxErrorModel = JsonSerializer.Serialize(new VisitorAddAjaxViewModel
                {
                    VisitorAddDto = visitorAddDto,
                    VisitorAddPartial = await this.RenderViewToStringAsync("_VisitorAddPartial", new VisitorAddDto
                    {

                        Departments = result.Data.Departments,
                        

                    })
                });
                    
                return Json(visitorAddAjaxErrorModel);


            }

        }
        [Authorize]
        public async Task<JsonResult> Delete(int visitorId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
          
            var result = await _visitorService.Delete(visitorId, user.UserName);
            if (result.ResultStatus==ResultStatus.Success)
            {
                var deletedResult = JsonSerializer.Serialize(new VisitorDto()
                {
                    ResultStatus = ResultStatus.Success,
                    Message = $"{result.Data.Visitor.FirstName} adına sahip ziyaretçi, başarıyla silinmiştir.",
                    Visitor = result.Data.Visitor
                }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve

                });
                return Json(deletedResult);
            }
            else
            {

                var visitorDeletedErrorModel = JsonSerializer.Serialize(new VisitorDto()
                {
                    Visitor = result.Data.Visitor,
                    ResultStatus = ResultStatus.Error,
                    Message = $"{result.Data.Visitor.FirstName} adına sahip ziyaretçi, silinememiştir."

                });
                return Json(visitorDeletedErrorModel);
            }



        }

        [Authorize]
        public async Task<JsonResult> IsExit(int visitorId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var visitor = await _visitorService.Get(visitorId);

            var result = await _visitorService.IsExit(visitorId, user.UserName);
            var department = await _departmentService.Get(visitor.Data.Visitor.DepartmentId);
            result.Data.Visitor.Department = department.Data.Department;
            result.Data.Visitor.OutDate = DateTime.Now;

            if (result.ResultStatus == ResultStatus.Success)
            {
                var IsExitResult = JsonSerializer.Serialize(new VisitorDto()
                {
                    ResultStatus = ResultStatus.Success,
                    Message = $"{result.Data.Visitor.FirstName} adına sahip ziyaretçi çıkış yapmıştır.",
                    Visitor = result.Data.Visitor
                }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve

                });
                return Json(IsExitResult);
            }
            else
            {

                var visitorIsExitErrorModel = JsonSerializer.Serialize(new VisitorDto()
                {
                    Visitor = result.Data.Visitor,
                    ResultStatus = ResultStatus.Error,
                    Message = $"{result.Data.Visitor.FirstName} adına sahip ziyaretçi,çıkış yapılamamıştır"

                });
                return Json(visitorIsExitErrorModel);
            }



        }



    }
}
