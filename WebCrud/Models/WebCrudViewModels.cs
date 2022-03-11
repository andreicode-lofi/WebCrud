using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCrud.Models
{
    public class WebCrudViewModels
    {
        public List<Formulario> Formulario { get; set; }
        public SelectList? Nome { get; set; }
        public string SobreNome{ get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento  { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
    }
}
