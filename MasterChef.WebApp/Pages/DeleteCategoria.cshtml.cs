using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasterChef.WebApp.Pages
{
    public class DeleteCategoriaModel : PageModel
    {
        private readonly HttpClient httpClient;

        public DeleteCategoriaModel(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage resposta = await httpClient.GetAsync($"http://localhost:5011/Categoria/{id}");
            resposta.EnsureSuccessStatusCode();

            Categoria = await resposta.Content.ReadAsAsync<Categoria>();

            if (Categoria == null)
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

            HttpResponseMessage resposta = await httpClient.DeleteAsync($"http://localhost:5011/Categoria/{id}");
            resposta.EnsureSuccessStatusCode();

            return RedirectToPage("./ListCategorias");
        }
    }
}