using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Keyworks.Persistence.Contextos;
using Keyworks.Persistence.Contratos;
using Keyworks.Persistence;
using Keyworks.Application.Contratos;
using Keyworks.Application;

namespace Keyworks.API
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
            services.AddDbContext<KeyworksContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            services.AddControllers();

            services.AddScoped<IGeralPersist, GeralPersist>();

            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IColaboradorPersist, ColaboradorPersist>();

            services.AddScoped<ITituloService, TituloService>();
            services.AddScoped<ITitulosPersist, TituloPersist>();

            services.AddScoped<IStatusCardService, StatusCardService>();
            services.AddScoped<IStatusCardPersist, StatusCardPersist>();

            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardPersist, CardPersist>();

            services.AddScoped<ISituacaoCardService, SituacaoCardService>();
            services.AddScoped<ISituacaoCardPersist, SituacaoCardPersist>();

            services.AddScoped<IPainelCardService, PainelCardService>();
            services.AddScoped<IPainelCardsPersist, PainelCardsPersist>();

            services.AddScoped<IPainelService, PainelService>();
            services.AddScoped<IPainelPersist, PainelPersist>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Keyworks.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Keyworks.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(cors => cors.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
