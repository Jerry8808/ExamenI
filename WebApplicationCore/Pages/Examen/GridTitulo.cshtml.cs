using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApplicationCore.Pages.Examen
{
    public class GridTituloModel : PageModel
    {
        private readonly ITituloServicio tituloServicio;

        public GridTituloModel(ITituloServicio tituloServicio)
        {
            this.tituloServicio = tituloServicio;
        }

        public IEnumerable<TituloEntity> GridList { get; set; } = new List<TituloEntity>();

        public string Mensaje { get; set; } = "";

        //Boton de eliminar
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await tituloServicio.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }
                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await tituloServicio.Delete(new()
                {
                    Id_Titulo = id
                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "El Titulo se elimino correctamente";
                //Redieccionamiento a la pagina principal
                return Redirect("GridTitulo");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
