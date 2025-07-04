using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BL
{
    public class Usuario
    { 

        private readonly DL.EjercicioGitAbril2025Context _context;

        public Usuario(DL.EjercicioGitAbril2025Context context) {
        
            _context = context;
        }
        //Metodo mostrar usuario por id con LinQ
        public ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                var query = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == idUsuario);
                if (query != null)
                {
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        //Metodo agregar con Linq
        public ML.Result Add(DL.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                var query = _context.Usuarios.Add(usuario);
                if (query != null)
                {
                    _context.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception ex) 
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        //Metodo eliminar con LinQ
        public ML.Result Delete(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                var query = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == idUsuario);
                if (query != null)
                {
                    _context.Usuarios.Remove(query);
                    _context.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public ML.Result Update(int IdUsuario, ML.Usuario Usuario) { 
        
            ML.Result result = new ML.Result();

            try {


                var usuario = (from theUser in _context.Usuarios
                               where theUser.IdUsuario == IdUsuario
                               select theUser).FirstOrDefault();

                usuario.IdUsuario = Usuario.IdUsuario;
                usuario.Nombre = Usuario.Nombre;
                usuario.ApellidoPaterno = Usuario.ApellidoPaterno;
                usuario.FechaNacimiento = Usuario.FechaNacimiento;

                //_context.Update(usuario);

                int filasAfectadas = _context.SaveChanges();

                if (filasAfectadas > 0)
                {
                    result.Correct = true;
                }
                else { 
                    result.Correct = false;
                }


            }
            catch (Exception ex) {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result GetAll() {

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            try { 
            
                var query = (from usuario in _context.Usuarios
                             select new
                             {
                                 usuario.IdUsuario,
                                 usuario.Nombre,
                                 usuario.ApellidoPaterno,
                                 usuario.FechaNacimiento

                             }).ToList();

                if (query.Count > 0)
                {

                    result.Correct = true;
                    foreach (var usuario in query) {

                        ML.Usuario usuarioTemporal = new ML.Usuario();
                        usuarioTemporal.IdUsuario = usuario.IdUsuario;
                        usuarioTemporal.Nombre = usuario.Nombre;
                        usuarioTemporal.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioTemporal.FechaNacimiento = usuario.FechaNacimiento;
                         

                        result.Objects.Add(usuarioTemporal);

                    }

                }
                else { 
                    result.Correct = false;
                }


            }
            catch (Exception ex) {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }


            return result;
        }
        //Metodo agregar con Linq
        public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                DL.Usuario Usuario = new DL.Usuario();
                Usuario.Nombre = usuario.Nombre;
                Usuario.ApellidoPaterno = usuario.ApellidoPaterno;
                Usuario.FechaNacimiento = usuario.FechaNacimiento;
                var query = _context.Usuarios.Add(Usuario);
                if (query != null) 
                {
                    _context.SaveChanges();
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se pudo guardar el usuario";
                }
            }
            catch (Exception ex) 
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        //Metodo eliminar con LinQ
        public ML.Result Delete(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try 
            {
                var query = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == idUsuario);
                if (query != null)
                {
                    _context.Usuarios.Remove(query);
                    _context.SaveChanges();
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se pudo eliminar el usuario";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

        }
    }
}
