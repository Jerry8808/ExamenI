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
    public class GridPuestoModel : PageModel
    {
        private readonly IPuestoServicio puestoServicio;

        public GridPuestoModel(IPuestoServicio puestoServicio)
        {
            this.puestoServicio = puestoServicio;
        }

        public IEnumerable<PuestoEntity> GridList { get; set; } = new List<PuestoEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await puestoServicio.Get();

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
                var result = await puestoServicio.Delete(new()
                {
                    Id_Puesto = id
                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "El Puesto se elimino correctamente";

                return Redirect("GridPuesto");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

    }
}


