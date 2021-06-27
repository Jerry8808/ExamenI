using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationCore.Pages.Examen
{
    public class GridDepartamentoModel : PageModel
    {
        private readonly IDepartamentoServicio departamentoServicio;

        public GridDepartamentoModel(IDepartamentoServicio departamentoServicio)
        {
            this.departamentoServicio = departamentoServicio;
        }

        public IEnumerable<DepartamentoEntity> GridList { get; set; } = new List<DepartamentoEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await departamentoServicio.Get();

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
                var result = await departamentoServicio.Delete(new()
                {
                    Id_Departamento = id
                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "El Departamento se elimino correctamente";

                return Redirect("GridDepartamento");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
