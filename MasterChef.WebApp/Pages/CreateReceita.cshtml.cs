using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.WebApp.Pages
{
    public class CreateReceitaModel : PageModel
    {
        private readonly HttpClient httpClient;

        public CreateReceitaModel(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public IEnumerable<SelectListItem> Categorias { get; set; }

        public async Task<IActionResult> OnGet()
        {
            HttpResponseMessage resultcategoria = await httpClient.GetAsync("http://localhost:5011/Categoria");
            resultcategoria.EnsureSuccessStatusCode();

            var listCategorias = await resultcategoria.Content.ReadAsAsync<IList<Categoria>>();

            Categorias = listCategorias.Select(u => new SelectListItem
            {
                Text = u.Descricao,
                Value = u.Id.ToString()
            });

            return Page();
        }

        [BindProperty]
        public ReceitaViewModel Receita { get; set; }
        
        public Receita ReceitaData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            HttpResponseMessage resultcategoria = await httpClient.GetAsync("http://localhost:5011/Categoria");
            resultcategoria.EnsureSuccessStatusCode();

            var ltCategoria = await resultcategoria.Content.ReadAsAsync<IList<Categoria>>();
            var categoria = ltCategoria.FirstOrDefault(c => c.Id == Receita.CategoriaId);

            var jsonContent = JsonConvert.SerializeObject(new Receita
            {
                Categoria = categoria,
                Descricao = Receita.Descricao,
                Foto = Receita.Foto,
                Ingredientes = Receita.Ingredientes,
                ModoPreparo = Receita.ModoPreparo,
                Tags = Receita.Tags,
                Titulo = Receita.Titulo
            });
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var resposta = await httpClient.PostAsync("http://localhost:5011/Receita", contentString);
            resposta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }

    public class ReceitaViewModel
    {

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Ingredientes { get; set; }

        [Required]
        public string ModoPreparo { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        public string Tags { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}