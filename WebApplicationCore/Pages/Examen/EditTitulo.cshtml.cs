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
    public class EditTituloModel : PageModel
    {
        private readonly ITituloServicio tituloServicio;

        public EditTituloModel(ITituloServicio tituloServicio)
        {
            this.tituloServicio = tituloServicio;
        }

        [BindProperty]
        public TituloEntity Entity { get; set; } = new TituloEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        //Boton Agregar
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await tituloServicio.GetById(new() { Id_Titulo = id });
                }
                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        //Boton Actualizar
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.Id_Titulo.HasValue)
                {
                    //Mensaje de Actualizacion
                    var result = await tituloServicio.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El Titulo se actualizo correctamente";
                }
                else
                {
                    //Mensaje de Agregado
                    var result = await tituloServicio.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El Titulo se agrego correctamente";
                }
                //Redirecionamiento a la pagina Principal
                return RedirectToPage("GridTitulo");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
