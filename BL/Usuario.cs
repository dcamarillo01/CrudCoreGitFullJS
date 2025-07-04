using DL;
using ML;
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

        public Usuario(DL.EjercicioGitAbril2025Context context)
        {

            _context = context;
        }
        //Metodo mostrar usuario por id con LinQ
        public ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                var query = _context.Usuarios.Where(u => u.IdUsuario == idUsuario)
                                .Select(u => new DL.Usuario
                                {
                                    IdUsuario = u.IdUsuario,
                                    Nombre = u.Nombre,
                                    ApellidoPaterno = u.ApellidoPaterno,
                                    FechaNacimiento = u.FechaNacimiento
                                }).FirstOrDefault();

                if (query != null)
                {
                    result.Object = query;
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "El usuario no se encontro";
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
                DL.Usuario Usuario = new DL.Usuario();
                Usuario.Nombre = usuario.Nombre;
                Usuario.ApellidoPaterno = usuario.ApellidoPaterno;
                Usuario.FechaNacimiento = usuario.FechaNacimiento;
                var query = _context.Usuarios.Add(usuario);
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

            return result;
        }
    }
}
