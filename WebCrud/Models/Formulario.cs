using System.ComponentModel.DataAnnotations;

namespace WebCrud.Models
{
    public class Formulario
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "SobreNome")]
        public string SobreNome { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Cpf")]
        public string Cpf { get; set; }
        [Display(Name = "Rg")]
        public string Rg { get; set; }
    }
}

