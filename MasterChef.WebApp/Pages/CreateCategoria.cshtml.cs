using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MasterChef.Infrastructure.Data;
using MasterChef.Infrastructure.Data.EntityConfigurations.API;

namespace MasterChef.WebApp.Pages
{
    public class CreateCategoriaModel : PageModel
    {
        private readonly MasterChef.Infrastructure.Data.ApplicationDbContext _context;

        public CreateCategoriaModel(MasterChef.Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categoria.Add(Categoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
