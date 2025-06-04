using CrudProductos.Datos;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace CrudProductos.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public IndexModel(ApplicationDbContext context)
        {  _context = context; }
        
        public IList<Producto>productos {  get; set; }
        public async Task OnGet()
        {
            productos= await _context.Productos.ToListAsync();
        }
    }
}
