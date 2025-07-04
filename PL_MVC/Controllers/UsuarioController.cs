using Microsoft.AspNetCore.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly BL.Usuario _usuario;

        public UsuarioController(BL.Usuario usuario) { 
        
            _usuario = usuario;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll() { 
        
            return View();


        }





        public JsonResult Add(string Nombre, string ApellidoPaterno, string FechaNaciemiento) {
            
            ML.Usuario usuario = new ML.Usuario();

            usuario.Nombre = Nombre;
            usuario.ApellidoPaterno = ApellidoPaterno;
            usuario.FechaNacimiento = DateOnly.Parse(FechaNaciemiento);

            ML.Result resultAdd = _usuario.Add(usuario);

        
        }


        public JsonResult Delete() { }

        public JsonResult GetById() {





    }
}
