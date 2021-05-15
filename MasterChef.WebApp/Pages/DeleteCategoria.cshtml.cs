using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MasterChef.Infrastructure.Data;
using MasterChef.Infrastructure.Data.EntityConfigurations.API;

namespace MasterChef.WebApp.Pages
{
    public class DeleteCategoriaModel : PageModel
    {
        private readonly MasterChef.Infrastructure.Data.ApplicationDbContext _context;

        public DeleteCategoriaModel(MasterChef.Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categoria.FirstOrDefaultAsync(m => m.Id == id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categoria.FindAsync(id);

            if (Categoria != null)
            {
                _context.Categoria.Remove(Categoria);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
