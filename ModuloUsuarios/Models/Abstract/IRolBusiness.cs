using ModuloUsuarios.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloUsuarios.Models.Abstract
{
    public interface IRolBusiness
    {
        Task<Rol> CrearRol(Rol rol);
    }
}
