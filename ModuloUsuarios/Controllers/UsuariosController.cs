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
    public class UsuariosController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuariosController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var listaUsuarios = await _usuarioBusiness.ListarUsuarios();
            return View(listaUsuarios);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> DetalleUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioBusiness.ObtenerUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["ListaRoles"] = new SelectList(await _usuarioBusiness.ListarRoles(), "RolId", "Nombre");

            return View(usuario);
        }


        //GET: Usuarios/Create
        public async Task<IActionResult> CrearUsuario()
        {
            ViewData["ListaRoles"] = new SelectList(await _usuarioBusiness.ListarRoles(), "RolId", "Nombre");
            return View();
        }


        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearUsuario(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                // var usuarioEnviado = _context.Usuarios.FirstOrDefault(x => x.Documento => usuario.Documento);

                await _usuarioBusiness.GuardarUsuario(usuario);
                TempData["mensaje"] = "El registro sea creado correctamente";
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListaRoles"] = new SelectList(await _usuarioBusiness.ListarRoles(), "RolId", "Nombre");

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> EditarUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioBusiness.ObtenerUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["ListaRoles"] = new SelectList(await _usuarioBusiness.ListarRoles(), "RolId", "Nombre");

            return View(usuario);
        }



        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _usuarioBusiness.EditarUsuario(usuario);
                TempData["mensaje"] = "El registro sea editado correctamente";
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListaRoles"] = new SelectList(await _usuarioBusiness.ListarRoles(), "RolId", "Nombre");

            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> EliminarUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioBusiness.ObtenerUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }


            await _usuarioBusiness.EliminarUsuario(usuario);
            TempData["mensaje"] = "El registro sea ha eliminado correctamente";

            return RedirectToAction(nameof(Index));
        }

        //// POST: Usuarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EliminarUsuarioConfirmar(int id)
        //{
        //    var usuario = await _usuarioBusiness.ObtenerUsuarioPorId(id);
        //    _usuarioBusiness.EliminarUsuario();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
