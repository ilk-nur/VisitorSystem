using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Entities.Dtos.RoleDto;
using VisitorSystem.Mvc.Areas.Admin.Models;
using VisitorSystem.Shared.Utilities.Extensions;
using VisitorSystem.Shared.Utilities.Results.ComplexTypes;

namespace VisitorSystem.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        public RoleController(RoleManager<Role> roleManager,IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {

            var roles = await _roleManager.Roles.ToListAsync();
            return View(new RoleListDto() { 
            
               Roles=roles,
               ResultStatus=ResultStatus.Success
            
            });

           
        }

        [HttpGet]
        public async Task<JsonResult> GetAllRoles()
        {

            var roles = await _roleManager.Roles.ToListAsync();
            var roleListDto = JsonSerializer.Serialize(new RoleListDto()
            {
                Roles = roles,
                ResultStatus = ResultStatus.Success


            }, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve


            });
            return Json(roleListDto);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return PartialView("_RoleAddPartial");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(RoleAddDto roleAddDto)
        {
            if (ModelState.IsValid)
            {
                var role = _mapper.Map<Role>(roleAddDto);
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    var roleAddAjaxModel = JsonSerializer.Serialize(new RoleAddAjaxViewModel
                    {
                        RoleDto = new RoleDto()
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{roleAddDto.Name} yetki adı, başarıyla eklenmiştir.",
                            
                        },
                        RoleAddPartial = await this.RenderViewToStringAsync("_RoleAddPartial", roleAddDto)


                    });
                    return Json(roleAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                    var roleAddAjaxErrorModel = JsonSerializer.Serialize(new RoleAddAjaxViewModel()
                    {
                        RoleAddDto = roleAddDto,
                        RoleAddPartial = await this.RenderViewToStringAsync("_RoleAddPartial", roleAddDto)

                    });          
                                   
                    return Json(roleAddAjaxErrorModel);
                }


            }
            else
            {
                var roleAddAjaxErrorModel = JsonSerializer.Serialize(new RoleAddAjaxViewModel()
                {
                    RoleAddDto = roleAddDto,
                    RoleAddPartial = await this.RenderViewToStringAsync("_RoleAddPartial", roleAddDto)

                });
                return Json(roleAddAjaxErrorModel);

            }

        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> Delete(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                var deletedResult = JsonSerializer.Serialize(new RoleDto()
                {
                    ResultStatus = ResultStatus.Success,
                    Message = $"{role.Name} adındaki yetki, başarıyla silinmiştir.",
                    Role=role
                });
                return Json(deletedResult);
            }
            else
            {

                var userDeletedErrorModel = JsonSerializer.Serialize(new RoleDto()
                {
                    Role = role,
                    ResultStatus = ResultStatus.Error,
                    Message = $"{role.Name} adındaki yetki, silinememiştir."

                });
                return Json(userDeletedErrorModel);
            }



        }
    }
}
