using Microsoft.EntityFrameworkCore;
using ModuloUsuarios.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloUsuarios.DAL
{
    public class DbContextModuloUsuarios : DbContext
    {
        // Constructor de la clase con los paremetros que exige la Clase DbContext
        public DbContextModuloUsuarios(DbContextOptions<DbContextModuloUsuarios> options) : base(options)
        {

        }

        // Creando las tablas
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Rol> Roles { get; set; }

    }
}
