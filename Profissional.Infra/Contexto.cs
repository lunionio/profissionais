using Microsoft.EntityFrameworkCore;
using Profissional.Dominio.Entidades;

namespace Profissional.Infra
{
    public class Contexto : DbContext
    {
        public DbSet<ServicoTipo> ServicoTipo { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<ProfissionalServico> ProfissionalServico { get; set; }
        public DbSet<Dominio.Entidades.Profissional> Profissional { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<ProfissionalFormacao> ProfissionalFormacao { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<ProfissionalXUrl> ProfissionalXUrl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=WIN-2V8OOHSRMOD;Database=Staffpro_Profissionais;Trusted_Connection=True;Integrated Security = True;");
            optionsBuilder.UseSqlServer(@"Data Source=18.229.17.132;Initial Catalog=Staffpro_Profissionais;Persist Security Info=True;User ID=sa;Password=StaffPro@123;");
        }
    }
}
