using BlazorWebshopUdemy.Data;
using BlazorWebshopUdemy.Stores.CounterStore;
using eShop.CoreBusiness.Services;
using eShop.DataStore.Hardcoded;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.SearchProductScreen;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorWebshopUdemy
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            // Own services
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISearchProduct, SearchProduct>();
            services.AddTransient<IViewProduct, ViewProduct>();

            services.AddScoped<CounterStore>();

            // Dependency Injection methods
            services.AddTransient<ICustomerService, CustomerService>(); // <- everytime we want to use this interface, its instantinate a new class for it
            //services.AddScoped<ICustomerService, CustomerService>(); // <- everytime we want to use this interface, it will give us an already instantinated class that is scoped to the connection
            //services.AddSingleton<ICustomerService, CustomerService>(); // <- everytime we want to use this interface, it will always give us the same class
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( "/Error" );
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapBlazorHub();
                 endpoints.MapFallbackToPage( "/_Host" );
             } );
        }
    }
}
