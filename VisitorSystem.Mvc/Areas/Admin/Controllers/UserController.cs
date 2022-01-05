using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Entities.Dtos.UserDto;
using VisitorSystem.Mvc.Areas.Admin.Models;
using VisitorSystem.Shared.Utilities.Extensions;
using VisitorSystem.Shared.Utilities.Results.ComplexTypes;

namespace VisitorSystem.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, IWebHostEnvironment env, IMapper mapper, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
            _mapper = mapper;

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(new UserListDto()
            {
                Users = users,
                ResultStatus = ResultStatus.Success


            });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("UserLogin");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-Posta adresiniz veya Şifreniz hatalı!");
                        return View("UserLogin");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-Posta adresiniz veya Şifreniz hatalı!");
                    return View("UserLogin");

                }

            }
            else
            {
                return View("UserLogin");
            }


        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "User");

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userListDto = JsonSerializer.Serialize(new UserListDto()
            {
                Users = users,
                ResultStatus = ResultStatus.Success


            }, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve


            });
            return Json(userListDto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                userAddDto.Picture = await ImageUpload(userAddDto.UserName, userAddDto.PictureFile);
                var user = _mapper.Map<User>(userAddDto);
                var result = await _userManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel()
                    {
                        UserDto = new UserDto()
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{userAddDto.UserName} adına sahip kullanıcı, başarıyla eklenmiştir.",
                            User = user
                        },
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)


                    });
                    return Json(userAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                    var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel()
                    {
                        UserAddDto = userAddDto,
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)

                    });
                    return Json(userAddAjaxErrorModel);
                }


            }
            else
            {
                var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel()
                {
                    UserAddDto = userAddDto,
                    UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)

                });
                return Json(userAddAjaxErrorModel);

            }

        }
        [Authorize(Roles = "Admin,Personal")]
        public async Task<string> ImageUpload(string userName, IFormFile pictureFile)
        {
            //~/img/user.picture
            string wwwroot = _env.WebRootPath;
            //alpertuga  
            //string fileName = Path.GetFileNameWithoutExtension(userAddDto.Picture.FileName);
            //.png
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;

            string fileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";

            var path = Path.Combine($"{wwwroot}/img", fileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }
            return fileName;



        }
        [Authorize(Roles = "Admin,Personal")]
        public bool ImageDelete(string pictureName)
        {
            string wwwroot = _env.WebRootPath;
            var fileToDelete = Path.Combine($"{wwwroot}/img", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                System.IO.File.Delete(fileToDelete);
                return true;

            }
            else
            {
                return false;
            }


        }
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> Delete(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                var deletedResult = JsonSerializer.Serialize(new UserDto()
                {
                    ResultStatus = ResultStatus.Success,
                    Message = $"{user.UserName} adına sahip kullanıcı, başarıyla silinmiştir.",
                    User = user
                });
                return Json(deletedResult);
            }
            else
            {

                var userDeletedErrorModel = JsonSerializer.Serialize(new UserDto()
                {
                    User = user,
                    ResultStatus = ResultStatus.Error,
                    Message = $"{user.UserName} adına sahip kullanıcı, silinememiştir."

                });
                return Json(userDeletedErrorModel);
            }



        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<PartialViewResult> Update(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var userUpdateDto = _mapper.Map<UserUpdateDto>(user);

            return PartialView("_UserUpdatePartial", userUpdateDto);


        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool imgIsTrue = false;
                var oldUser = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
                var oldPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    userUpdateDto.Picture = await ImageUpload(userUpdateDto.UserName, userUpdateDto.PictureFile);
                    imgIsTrue = true;

                }
                var updateUser = _mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await _userManager.UpdateAsync(updateUser);
                if (result.Succeeded)
                {
                    if (imgIsTrue)
                    {
                        ImageDelete(oldPicture);
                    }
                    var userUpdateViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel()
                    {
                        UserDto = new UserDto()
                        {
                            User = updateUser,
                            ResultStatus = ResultStatus.Success,
                            Message = $"{updateUser.UserName} adlı kullanıcı başarıyla güncellenmiştir."
                        },
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)

                    });
                    return Json(userUpdateViewModel);

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                    var userUpdateErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel()
                    {
                        UserUpdateDto = userUpdateDto,
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)

                    });
                    return Json(userUpdateErrorViewModel);
                }
            }
            else
            {
                var userUpdateErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel()
                {
                    UserUpdateDto = userUpdateDto,
                    UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)

                });
                return Json(userUpdateErrorViewModel);

            }
        }
        [Authorize]
        [HttpGet]
        public ViewResult ChangePassword()
        {
            return View();
                 


        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserPasswordChangeDto userPasswordChangeDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var IsVerifield = await _userManager.CheckPasswordAsync(user, userPasswordChangeDto.CurrentPassword);
                if (IsVerifield)
                {
                    var result = await _userManager.ChangePasswordAsync(user, userPasswordChangeDto.CurrentPassword, userPasswordChangeDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userPasswordChangeDto.NewPassword, true, false);
                        TempData.Add("SuccessMessage", "Şifreniz başarıyla değiştirilmiştir.");
                        return View();

                    }
                    

                }
                else
                {
                    ModelState.AddModelError("", "Lütfen girmiş olduğunuz şuanki şifrenizi kontrol ediniz.");
                    return View(userPasswordChangeDto); 

                }


            }
            else
            {
                return View(userPasswordChangeDto);

            }
            return View();



        }


        [Authorize]
        [HttpGet]
        public async Task<ViewResult> ChangeDetails()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var updateDto = _mapper.Map<UserUpdateDto>(user);
            return View(updateDto);
        }
        [Authorize]
        [HttpPost]
        public async Task<ViewResult> ChangeDetails(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool imgIsTrue = false;
                var oldUser = await _userManager.GetUserAsync(HttpContext.User);
                var oldPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    userUpdateDto.Picture = await ImageUpload(userUpdateDto.UserName, userUpdateDto.PictureFile);
                    if (oldPicture != "DefaultUser.png")
                    {
                        imgIsTrue = true;
                    }


                }
                var updateUser = _mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await _userManager.UpdateAsync(updateUser);
                if (result.Succeeded)
                {
                    if (imgIsTrue)
                    {
                        ImageDelete(oldPicture);
                    }
                    TempData.Add("SuccessMessage", $"{updateUser.UserName} adlı kullanıcı başarıyla güncellenmiştir.");
                    return View(userUpdateDto);

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                    return View(userUpdateDto);
                }
            }
            else
            {
                return View(userUpdateDto);


            }
        }

        [HttpGet]
        public ViewResult AccessDenied()
        {
            return View();
        }
}   }

