using ModuloUsuarios.DAL;
using ModuloUsuarios.Models.Abstract;
using ModuloUsuarios.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloUsuarios.Models.Business
{
    public class RolBusiness : IRolBusiness
    {

        private readonly DbContextModuloUsuarios _context;

        public RolBusiness(DbContextModuloUsuarios context)
        {
            _context = context;
        }


        public async Task<Rol> CrearRol(Rol rol)
        {
            try
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return rol;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
