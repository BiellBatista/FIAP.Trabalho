using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChef.WebApp.Pages
{
    public class CreateReceitaModel : PageModel
    {
        private readonly MasterChef.Infrastructure.Data.ApplicationDbContext _context;

        public CreateReceitaModel(MasterChef.Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<string> Categorias { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var listCategorias = await _context.Categoria.ToListAsync();

            Categorias = listCategorias.Select(c => c.Descricao);

            return Page();
        }

        [BindProperty]
        public Receita Receita { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Receita.Add(Receita);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}