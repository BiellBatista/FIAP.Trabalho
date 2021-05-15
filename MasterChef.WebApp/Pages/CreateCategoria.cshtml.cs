using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.WebApp.Pages
{
    public class CreateCategoriaModel : PageModel
    {
        private readonly HttpClient httpClient;

        public CreateCategoriaModel(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonContent = JsonConvert.SerializeObject(Categoria);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var resposta = await httpClient.PostAsync("http://localhost:5011/Categoria", contentString);
            resposta.EnsureSuccessStatusCode();

            return RedirectToPage("./ListCategorias");
        }
    }
}