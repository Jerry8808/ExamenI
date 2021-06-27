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
    public class EditPuestoModel : PageModel
    {
        private readonly IPuestoServicio puestoServicio;

        public EditPuestoModel(IPuestoServicio puestoServicio)
        {
            this.puestoServicio = puestoServicio;
        }

        [BindProperty]
        public PuestoEntity Entity { get; set; } = new PuestoEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await puestoServicio.GetById(new() { Id_Puesto = id });
                }
                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.Id_Puesto.HasValue)
                {
                    var result = await puestoServicio.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El Puesto se actualizo correctamente";
                }
                else
                {
                    var result = await puestoServicio.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El Puesto se agrego correctamente";
                }
                return RedirectToPage("GridPuesto");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}

