using CrudProductos.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;

namespace CrudProductos.Pages.Productos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CrearModel(ApplicationDbContext contex)
        {
            _context=contex;
        }
       

        [BindProperty]
        public Producto Producto { get; set; }


        public  IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Producto.FechaCreacion = DateTime.Now;
            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
       
    }
}
