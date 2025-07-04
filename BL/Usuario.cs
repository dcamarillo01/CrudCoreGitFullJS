using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    { 

        private readonly DL.EjercicioGitAbril2025Context _context;

        public Usuario(DL.EjercicioGitAbril2025Context context) {
        
            _context = context;
        }
        public ML.Result Delete(int idUsuario)
        {
            ML.Result result = new ML.Result();
            var query = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == idUsuario);
            if (query != null)
            {
                _context.Usuarios.Remove(query);
                _context.SaveChanges();
            }
            return result;
        }
    }
}
