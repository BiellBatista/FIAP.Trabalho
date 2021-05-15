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

            listReceita.ForEach(r => {
                if (r.Categoria != null)
                {
                    r.Categoria.Receitas = null;
                }
            });

            return listReceita;
        }

        [HttpGet("{id}")]
        public async Task<Receita> GetAsync(int? id)
        {
            if (id is null)
            {
                return new Receita();
            }
            var receita = await context.Receita.Include(r => r.Categoria).FirstOrDefaultAsync(m => m.Id == id);
            receita.Categoria.Receitas = null;
            return await context.Receita.FirstOrDefaultAsync(m => m.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Receita model)
        {
            context.Receita.Add(model);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id is null)
            {
                return Ok();
            }
            var result = await context.Receita.FindAsync(id);
            if (result != null)
            {
                context.Receita.Remove(result);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}