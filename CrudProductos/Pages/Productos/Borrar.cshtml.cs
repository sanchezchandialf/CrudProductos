using CrudProductos.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace CrudProductos.Pages.Productos
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public BorrarModel(ApplicationDbContext contex)
        {
            _context = contex;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
            if (Producto == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (Producto == null)
            {
                return NotFound();
            }

            var productoBorrar = await _context.Productos.FindAsync(Producto.Id);
            if (productoBorrar == null)
            {
              _context.Productos.Remove(Producto);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
