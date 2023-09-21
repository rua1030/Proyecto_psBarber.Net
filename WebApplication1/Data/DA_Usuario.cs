using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DA_Usuario
    {
        private readonly ApplicationDbContext _context;

        public DA_Usuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Usuario> ListaUsuario()
        {
            return _context.Usuario.ToList();
        }

        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return _context.Usuario.FirstOrDefault(u => u.Correo == _correo && u.Clave == _clave);
        }
    }
}
