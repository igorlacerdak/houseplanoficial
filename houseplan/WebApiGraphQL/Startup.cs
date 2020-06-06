using System;
using System.Collections.Generic;
using System.Linq;
using GraphiQl;
using GraphQL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiGraphQL.Queries;
using WebApiGraphQL.Mutations;
using WebApiGraphQL.Types;
using HousePlan.Dados;
using HousePlan.Servico;

namespace WebApiGraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"appsetings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();

                WebHostEnvironment = env;
        }


        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.
        AddMvc(option => option.EnableEndpointRouting = false)
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddTransient<IUsuarioServico, UsuarioServico>();
            services.AddControllers();
            services.AddScoped<BlogSchema>();
            services.AddScoped<UsuarioServico>();
            services.AddScoped<BlogQuery>();
            services.AddScoped<BlogMutation>();
            services.AddScoped<UsuarioType>();
            services.AddScoped<UsuarioInputType>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseGraphiQl();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
