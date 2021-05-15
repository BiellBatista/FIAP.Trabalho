using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MasterChef.Infrastructure.Data;
using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace MasterChef.WebApp.Pages
{
    public class EditReceitaModel : PageModel
    {
        private readonly HttpClient httpClient;

        public EditReceitaModel(HttpClient httpClient)
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

            HttpResponseMessage resultcategoria = await httpClient.GetAsync("http://localhost:5011/Categoria");
            resultcategoria.EnsureSuccessStatusCode();
            var listCategorias = await resultcategoria.Content.ReadAsAsync<IEnumerable<Categoria>>();

            HttpResponseMessage result = await httpClient.GetAsync($"http://localhost:5011/Receita/{id}");
            result.EnsureSuccessStatusCode();

            Receita = await result.Content.ReadAsAsync<Receita>();

            if (Receita == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(listCategorias, "Id", "Descricao");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonContent = JsonConvert.SerializeObject(Receita);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var resposta = await httpClient.PutAsync("http://localhost:5011/Rceeita", contentString);

            resposta.EnsureSuccessStatusCode();

            return RedirectToPage("./ListReceitas");
        }
    }
}
