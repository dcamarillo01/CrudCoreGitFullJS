using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly BL.Usuario _usuario;

        public UsuarioController(BL.Usuario usuario)
        {

            _usuario = usuario;
        }


        public IActionResult Index()
        {
            return View();
        }


        // ========= VISTA GETALL =========== \\
        public IActionResult GetAll()
        {

            return View();

        }

        // ========= VISTA FORMULARIO ============= \\

        public IActionResult Formulario() {

            return View();
        }

        public JsonResult GetAllJson()
        {
            ML.Result result = _usuario.GetAll();
            if (result.Correct)
            {
                return Json(result);
            }
            else
            {
                return Json(result.ErrorMessage);
            }
        }
        public JsonResult Update(int idusuario, ML.Usuario usuario)
        {
            

            usuario.IdUsuario = idusuario;
            ML.Result result = _usuario.Update(idusuario,usuario);
            if (result.Correct)
            {
                return Json(result);
            }
            else
            {
                return Json(result.ErrorMessage);
            }
        }
        [HttpPost]
        public JsonResult Add(ML.Usuario usuario)
        {


            ML.Result resultAdd = _usuario.Add(usuario);



            return Json(resultAdd);
        }


        public JsonResult Delete(int IdUsuario)
        {

            ML.Result resultDelete = _usuario.Delete(IdUsuario);

            return Json(resultDelete);
        }

        [HttpGet]
        public JsonResult GetById(int IdUsuario)
        {

            ML.Result resultGetById = _usuario.GetById(IdUsuario);

            return Json(resultGetById);

        }




    }
}
