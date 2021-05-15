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
    public class ListReceitasModel : PageModel
    {
        private readonly MasterChef.Infrastructure.Data.ApplicationDbContext _context;

        public ListReceitasModel(MasterChef.Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Receita> Receita { get;set; }

        public async Task OnGetAsync()
        {
            Receita = await _context.Receita
                .Include(r => r.Categoria).ToListAsync();
        }
    }
}
