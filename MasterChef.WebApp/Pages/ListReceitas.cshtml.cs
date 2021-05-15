using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasterChef.WebApp.Pages
{
    public class ListReceitasModel : PageModel
    {
        private readonly HttpClient httpClient;

        public ListReceitasModel(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public IList<Receita> Receita { get; set; }

        public async Task OnGetAsync()
        {
            HttpResponseMessage resposta = await httpClient.GetAsync("http://localhost:5011/Receita");
            resposta.EnsureSuccessStatusCode();

            Receita = await resposta.Content.ReadAsAsync<IList<Receita>>();
        }
    }
}