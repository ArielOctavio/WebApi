using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    public class UserLoginsController : Controller
    {
        private readonly WebApiContext _context;

        public UserLoginsController(WebApiContext context)
        {
            _context = context;
        }

        // GET: UserLogins
        public async Task<IActionResult> Index()
        {
            var ret = await _context.userLogin.ToListAsync();
            if(ret==null || ret.Count==0 )
            {
                var error = new ErrorRequest();
                error.Message = "no hay usuarios";


                return BadRequest(new JsonResult(error));
            }

            return Ok(new JsonResult(ret));
        }

        // GET: UserLogins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                var errorNull = new ErrorRequest();
                errorNull.Message = "debe indicar el id del usuario";

                return NotFound(new JsonResult(errorNull));
            }

            var userLogin = await _context.userLogin
                .FirstOrDefaultAsync(m => m.Id == id);


            if (userLogin == null)
            {
                var error = new ErrorRequest();
                error.Message = "No existe el usuario";

                return NotFound(error.ToJson());
            }

            return Ok(new JsonResult(userLogin));
        }

        // GET: UserLogins/Create
        public IActionResult Create()
        {
            var error = new ErrorRequest("la solicitud debe ser por POST");
            return NotFound(error.ToJson());
        }

        // POST: UserLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] userLogin userLogin)
        {

            if (ModelState.IsValid)
            {
                //Encriptar pass
                userLogin.Password =Seguridad.Encriptarpass(userLogin.Password);


                _context.Add(userLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLogin);
        }

        // GET: UserLogins/Edit/5
        public  IActionResult Edit(int? id)
        {
            var error = new ErrorRequest("la solicitud debe ser por POST");
            return NotFound(error.ToJson());
        }

        // POST: UserLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] userLogin userLogin)
        {
            if (id != userLogin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userLoginExists(userLogin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userLogin);
        }

        // GET: UserLogins/Delete/5
        public IActionResult Delete(int? id)
        {
            var error = new ErrorRequest("la solicitud debe ser por POST");
            return NotFound(error.ToJson());
        }

        // POST: UserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        ///[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userLogin = await _context.userLogin.FindAsync(id);
            _context.userLogin.Remove(userLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userLoginExists(int id)
        {
            return _context.userLogin.Any(e => e.Id == id);
        }


      
    }
}
