using ModuloUsuarios.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloUsuarios.Models.Abstract
{
    public interface IUsuarioBusiness
    {
        Task<IEnumerable<Usuario>> ListarUsuarios();
        Task<IEnumerable<Rol>> ListarRoles();
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task<Usuario> GuardarUsuario(Usuario usuario);
        Task<Usuario> EditarUsuario(Usuario usuario);
        Task<Usuario> EliminarUsuario(Usuario usuario);
    }
}
