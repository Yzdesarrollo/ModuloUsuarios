using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModuloUsuarios.DAL;
using ModuloUsuarios.Models.Abstract;
using ModuloUsuarios.Models.Entities;

namespace ModuloUsuarios.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolBusiness _rolBusiness;

        public RolesController(IRolBusiness rolBusiness)
        {
            _rolBusiness = rolBusiness;
        }

        // GET: Roles
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Roles.ToListAsync());
        //}

        //// GET: Roles/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rol = await _context.Roles
        //        .FirstOrDefaultAsync(m => m.RolId == id);
        //    if (rol == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rol);
        //}

        // GET: Roles/Create
        public IActionResult CrearRoles()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearRoles(Rol rol)
        {
            if (ModelState.IsValid)
            {
                await _rolBusiness.CrearRol(rol);

                return RedirectToAction("Index", "Usuarios");
            }
            return View(rol);
        }

        // GET: Roles/Edit/5
        //public async Task<IActionResult> EditarRol(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rol = await _rolBusiness.Rol.FindAsync(id);
        //    if (rol == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(rol);
        //}

        //// POST: Roles/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditarRol(int id, [Bind("RolId,Nombre")] Rol rol)
        //{
        //    if (id != rol.RolId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(rol);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RolExists(rol.RolId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(rol);
        //}

        //// GET: Roles/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rol = await _context.Roles
        //        .FirstOrDefaultAsync(m => m.RolId == id);
        //    if (rol == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rol);
        //}

        //// POST: Roles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var rol = await _context.Roles.FindAsync(id);
        //    _context.Roles.Remove(rol);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RolExists(int id)
        //{
        //    return _context.Roles.Any(e => e.RolId == id);
        //}
    }
}
