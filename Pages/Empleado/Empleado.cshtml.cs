using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SucursalesWeb.Service;

namespace MyApp.Namespace
{
    public class EmpleadoModel : PageModel
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoModel(IEmpleadoService empleadoService){
            _empleadoService = empleadoService;
        }

        public IEnumerable<EmpleadoDto>? Empleados { get; set; }
        public async Task OnGetAsync()
        {
            Empleados = await _empleadoService.GetAllAsync();
        }
    }
}
