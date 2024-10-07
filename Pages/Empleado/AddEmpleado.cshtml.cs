using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SucursalesWeb.Service;
using System.Threading.Tasks;

namespace MyApp.Namespace
{
    public class AddEmpleadoModel : PageModel
    {
        private readonly IEmpleadoService _empleadoService;

        public AddEmpleadoModel(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [BindProperty]
        public Empleado NewEmpleado { get; set; } = new Empleado(); 

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            var result = await _empleadoService.AddAsync(NewEmpleado);
            if (result)
            {
                return RedirectToPage("Empleado"); 
            }

            ModelState.AddModelError("", "Error al agregar el empleado.");
            return Page(); 
        }
    }
}
