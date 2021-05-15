using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasterChef.WebApp.Pages
{
    public class ListCategoriasModel : PageModel
    {
        private readonly HttpClient httpClient;

        public ListCategoriasModel(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public IList<Categoria> Categoria { get; set; }

        public async Task OnGetAsync()
        {
            HttpResponseMessage resposta = await httpClient.GetAsync("http://localhost:5011/Categoria");
            resposta.EnsureSuccessStatusCode();

            Categoria = await resposta.Content.ReadAsAsync<IList<Categoria>>();
        }
    }
}