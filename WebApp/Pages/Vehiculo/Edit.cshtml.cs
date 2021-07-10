using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Vehiculo
{
    public class EditModel : PageModel
    {
        private readonly IVehiculoService vehiculoService;
        private readonly IMarcaVehiculoService marcaVehiculoService;

        public EditModel(IVehiculoService vehiculoService, IMarcaVehiculoService marcaVehiculoService)
        {
            this.vehiculoService = vehiculoService;
            this.marcaVehiculoService = marcaVehiculoService;
            
        }

        [BindProperty]
        public VehiculoEntity Entity { get; set; } = new VehiculoEntity();

        public IEnumerable<MarcaVehiculoEntity> MarcaVehiculoLista { get; set; } = new List<MarcaVehiculoEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await vehiculoService.GetById(entity: new() { VehiculoId = id });
                }

                MarcaVehiculoLista = await marcaVehiculoService.GetLista();

                return Page();

            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }

        }


        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.MarcaVehiculoId.HasValue)
                {
                    //Actualizar
                    var result = await vehiculoService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizo Correctamente";
                }
                else
                {
                    //Nuevo
                    var result = await vehiculoService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agrego Correctamente";

                }


                return RedirectToPage("Grid");

            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }

        }
    }
}
