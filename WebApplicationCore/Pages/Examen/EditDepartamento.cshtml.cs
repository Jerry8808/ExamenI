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
    public class EditDepartamentoModel : PageModel
    {
        private readonly IDepartamentoServicio departamentoServicio;

        public EditDepartamentoModel(IDepartamentoServicio departamentoServicio)
        {
            this.departamentoServicio = departamentoServicio;
        }

        [BindProperty]
        public DepartamentoEntity Entity { get; set; } = new DepartamentoEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await departamentoServicio.GetById(new() { Id_Departamento = id });
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
                if (Entity.Id_Departamento.HasValue)
                {
                    var result = await departamentoServicio.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El Departamento se actualizo correctamente";
                }
                else
                {
                    var result = await departamentoServicio.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El Departamento se agrego correctamente";
                }
                return RedirectToPage("GridDepartamento");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
