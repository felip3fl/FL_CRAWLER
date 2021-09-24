using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Puan.Business.Interfaces.Adapter;
using Puan.Business.Interfaces.Services;
using Puan.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Puan.Infra.CrawlerOncid.Adapter;
using Puan.Infra.CrawlerOncid.Component.Interface;
using Puan.Infra.CrawlerOncid.Component.Crawler;
using Puan.Business.Interfaces.Repositories.Dapper;
using Puan.Infra.Data.Repositorios.Dapper.Base;
using Puan.Infra.Data.Repositorios.Dapper;
using Puan.Infra.Data.Interfaces.ConexaoBase;
using Puan.Infra.Data.Repositorios.RepositorioConexao.Conexao;
using Puan.Infra.Data.Interfaces.Context;
using Puan.Infra.Data.Context;
using Puan.Infra.Data.Repositorios.RepositorioConexao.Conexoes;

namespace Puan.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Puan.API", Version = "v1" });
            });

            services.AddTransient<Contexto>();
            services.AddTransient<IContexto, Contexto>();
            services.AddScoped<IFactoryConexaoBase, FactoryConexaoBase>();
            services.AddScoped<IConexaoBase, ShadowConexaoBase>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IPointTimeRepositoryDap, PointTimeRepositoryDap>();

            services.AddTransient<IOncidService, OncidService>();
            services.AddTransient<IPointTimeService, PointTimeService>();
            services.AddTransient<ICrawlerOncidAdapter, CrawlerOncidAdapter>();
            services.AddTransient<ICrawlerOncidConector, CrawlerOncid>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Puan.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
