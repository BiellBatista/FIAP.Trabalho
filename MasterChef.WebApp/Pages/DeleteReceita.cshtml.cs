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
    public class DeleteReceitaModel : PageModel
    {
        private readonly HttpClient httpClient;

        public DeleteReceitaModel(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        [BindProperty]
        public Receita Receita { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage resposta = await httpClient.GetAsync($"http://localhost:5011/Receita/{id}");
            resposta.EnsureSuccessStatusCode();

            Receita = await resposta.Content.ReadAsAsync<Receita>();

            if (Receita == null)
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

            HttpResponseMessage resposta = await httpClient.DeleteAsync($"http://localhost:5011/Receita/{id}");
            resposta.EnsureSuccessStatusCode();

            return RedirectToPage("./ListReceitas");
        }
    }
}
