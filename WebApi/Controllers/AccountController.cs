using Funciones;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        private readonly WebApiContext _context;

        public AccountController(WebApiContext context)
        {
            _context = context;
        }


        public JsonResult Index()
        {
            var user = new userLogin();
            user.Email = "ariel@ariel.com";
            user.Password = "12343";


            return Json(user);
        }


        [HttpPost]
        public IActionResult Login([FromBody] userLogin model)
        {

            var PassEncript = Seguridad.Encriptarpass(model.Password);
            var user = _context.userLogin.Where(u => u.Email == model.Email && u.Password == PassEncript).FirstOrDefault();

            if (user != null)
            {
                if(user.Token==null)
                {
                    setToken(user);
                }
                var userRet = new userReturn(user.Nombre, user.Apellido, user.Token);

                return Ok(new JsonResult(userRet));
            }

            var error = new ErrorRequest("Datos incorrectos");
            return  NotFound(error.ToJson());
        }

        private string setToken(userLogin user)
        {

            user.Token =  Guid.NewGuid().ToString();

            _context.Update(user);
            _context.SaveChanges();
            return user.Token;


        }
    }
}
