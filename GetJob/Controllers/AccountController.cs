using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using GetJob.Models;
using GetJob.Data;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace GetJob.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationDbContext _context;


        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            RegisterModel model1 = new RegisterModel();
            /*  model1.RoleList = _context.Roles
                               .Select(a => new SelectListItem()
                               {
                                   Value = a.Id.ToString(),
                                   Text = a.Name
                               })
                               ;
              ViewBag.DropDownList = model1.RoleList;*/
            model1.RoleList = new SelectList(_context.Roles, "Id", "Name");
            ViewBag.Roles = model1.RoleList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

                Users user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                var role = _context.Roles.Where(x => x.Id == Convert.ToInt32(model.Name));


                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new Users { Email = model.Email, Password = model.Password, Role = role.FirstOrDefault() };


                    _context.Users.Add(user);

                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
            }

            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");


            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await _context.Users
                                    .Include(u => u.Role)
                                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(Users user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
