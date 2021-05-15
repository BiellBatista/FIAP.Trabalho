using MasterChef.Infrastructure.Data;
using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterChef.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await context
                .Categoria
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Categoria> GetAsync(int? id)
        {
            if (id is null)
            {
                return new Categoria();
            }

            return await context.Categoria.FirstOrDefaultAsync(m => m.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria model)
        {
            context.Categoria.Add(model);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Categoria model)
        {
            try
            {
                context.Attach(model).State = EntityState.Modified;

                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id is null)
            {
                return Ok();
            }

            var result = await context.Categoria.FindAsync(id);

            if (result != null)
            {
                context.Categoria.Remove(result);
                await context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}