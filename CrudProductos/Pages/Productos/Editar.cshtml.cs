using CrudProductos.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace CrudProductos.Pages.Productos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditarModel(ApplicationDbContext contex)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Producto.FechaCreacion = DateTime.Now;
            _context.Attach(Producto).State = EntityState.Modified;
            try
            {

              await _context.SaveChangesAsync();
           
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(Producto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("Index");
        }
        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(p => p.Id == id);
        }
}
