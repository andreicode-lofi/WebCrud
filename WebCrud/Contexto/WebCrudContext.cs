using Microsoft.EntityFrameworkCore;

namespace WebCrud.Contexto
{
    public class WebCrudContext : DbContext
    {
        public WebCrudContext(DbContextOptions<WebCrudContext> options) : base(options)
        {
        }

        public DbSet<WebCrud.Models.Formulario> Formulario { get; set; }    
    }
}
