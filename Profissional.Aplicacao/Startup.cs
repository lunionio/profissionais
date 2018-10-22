using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profissional.Repositorio;
using Profissional.Servico;

namespace Profissional.Aplicacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ProfissionalService>();
            services.AddTransient<TelefoneService>();
            services.AddTransient<EnderecoService>();
            services.AddTransient<ProfissionalRepository>();
            services.AddTransient<TelefoneRepository>();
            services.AddTransient<EnderecoRepository>();
            services.AddTransient<FormacaoService>();
            services.AddTransient<FormacaoRepository>();
            services.AddTransient<ProfissionalServicoRep>();
            services.AddTransient<ServicoRep>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
