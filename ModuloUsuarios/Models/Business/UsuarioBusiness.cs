
using Microsoft.EntityFrameworkCore;
using ModuloUsuarios.DAL;
using ModuloUsuarios.Models.Abstract;
using ModuloUsuarios.Models.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloUsuarios.Models.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly DbContextModuloUsuarios _context;

        public UsuarioBusiness(DbContextModuloUsuarios context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return await _context.Usuarios.Include("Rol").ToListAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.UsuarioId == id);
            return usuario;
        }

        public async Task<IEnumerable<Rol>> ListarRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Usuario> GuardarUsuario(Usuario usuario)
        {
            try
            {

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<Usuario> EditarUsuario(Usuario usuario)
        {
            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<Usuario> EliminarUsuario(Usuario usuario)
        {
            try
            {
                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
