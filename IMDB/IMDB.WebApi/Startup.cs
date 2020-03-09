using IMDB.EntityModels;
using IMDB.NHibernate;
using IMDB.Services;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using IMDB.Services.Mapping;
using IMDB.Services.Mapping.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Support;
using System;

namespace IMDB.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; internal set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews();

            // services.AddSingleton<IStorage, InMemoryStorage>();

            // data access services configuration
            services.AddSingleton(provider =>
            {
                //provider.GetService<Microsoft.Extensions.Logging.ILoggerFactory>().UseAsHibernateLoggerFactory();
                return new Configuration() /*IMDB ES UN ALIAS QUE VOY A USAR PARA AGREGAR EN APPSETTINGS EL CONNECTION STRING*/
                    .SetupConnection(Configuration.GetConnectionString("IMDB"), new MsSql2012Dialect())
                    .AddClassMappingAssemblies(typeof(AssemblyLocator).Assembly);
            });
            services.AddSingleton(provider => provider.GetService<Configuration>().BuildSessionFactory());
            services.AddScoped(provider => provider.GetService<ISessionFactory>().OpenSession());

            // data mapping services configuration
            services.AddScoped<IEntityMapper<Movie, MovieDto>, MovieMapper>();
            services.AddScoped<IEntityMapper<Actor, ActorDto>, ActorMapper>();

            // add entities services
            services.AddScoped<IMovieService, MovieServices>();
            services.AddScoped<IActorService, ActorServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
