using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_de_pokemon.Context;
using Microsoft.EntityFrameworkCore;
using api_de_pokemon.Repositories;
using api_de_pokemon.Repositories.Implementation;
using api_de_pokemon.Services;
using api_de_pokemon.Services.Implementation;

namespace api_de_pokemon
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<ContextDb>(options =>
            {
                options.EnableSensitiveDataLogging(true);
                options.UseSqlite(Configuration.GetConnectionString("DefaultConn"));
            }
            );
            services.AddControllers();
            services.AddTransient<ITypesRepository, TypesRepository>();
            services.AddTransient<IAbilitiesRepository, AbilitiesRepository>();
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<ITypesServices, TypesServices>();
            services.AddTransient<IAbilitiesServices, AbilitiesServices>();
            services.AddTransient<IPokemonServices, PokemonServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
