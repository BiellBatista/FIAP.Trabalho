using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.WebApp.Pages
{
    public class EditCategoriaModel : PageModel
    {
        private readonly HttpClient httpClient;

        public EditCategoriaModel(HttpClient httpClient)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonContent = JsonConvert.SerializeObject(Categoria);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var resposta = await httpClient.PutAsync("http://localhost:5011/Categoria", contentString);

            resposta.EnsureSuccessStatusCode();

            return RedirectToPage("./ListCategorias");
        }
    }
}