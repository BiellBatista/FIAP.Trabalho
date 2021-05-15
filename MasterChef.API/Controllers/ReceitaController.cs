using MasterChef.Infrastructure.Data;
using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterChef.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ReceitaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Receita>> Get()
        {
            var listReceita = await context
                .Receita
                .Include(r => r.Categoria)
                .ToListAsync();

            listReceita.ForEach(r => r.Categoria.Receitas = null);

            return listReceita;
        }
    }
}