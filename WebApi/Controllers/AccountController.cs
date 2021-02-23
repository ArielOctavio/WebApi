using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        public JsonResult Index()
        {
            var user = new userLogin();
            user.Email = "ariel@ariel.com";
            user.Password = "12343";


            return Json(user);
        }


        public JsonResult Login()
        {

            var ret = "Hola que tal";
            return Json(ret);
         }
    }
}
