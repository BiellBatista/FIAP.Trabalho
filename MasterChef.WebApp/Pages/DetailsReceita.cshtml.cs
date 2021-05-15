using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MasterChef.Infrastructure.Data;
using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using System.Net.Http;

namespace MasterChef.WebApp.Pages
{
    public class DetailsReceitaModel : PageModel
    {
        private readonly HttpClient httpClient;

        public DetailsReceitaModel(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Receita Receita { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage result = await httpClient.GetAsync($"http://localhost:5011/Receita/{id}");
            result.EnsureSuccessStatusCode();

            Receita = await result.Content.ReadAsAsync<Receita>();

            if (Receita == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
