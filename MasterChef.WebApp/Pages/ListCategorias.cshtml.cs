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
    public class ListCategoriasModel : PageModel
    {
        private readonly MasterChef.Infrastructure.Data.ApplicationDbContext _context;

        public ListCategoriasModel(MasterChef.Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categoria { get;set; }

        public async Task OnGetAsync()
        {
            Categoria = await _context.Categoria.ToListAsync();
        }
    }
}
