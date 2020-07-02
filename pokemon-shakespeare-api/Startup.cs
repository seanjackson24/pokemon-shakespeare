using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PokemonShakespeare.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		private const string CorsPolicy = "CorsPolicy";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(c => c.AddPolicy(CorsPolicy, builder =>
			{
				builder.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod();

			}));

			services.AddControllersWithViews();

			services.AddHttpClient<PokemonApiClient>();
			services.AddHttpClient<ShakespeareApiClient>();
			services.AddSingleton(typeof(IPokemonFetchService), typeof(PokemonFetchService));
			services.AddSingleton(typeof(IPokemonApiService), typeof(PokemonApiService));
			services.AddSingleton(typeof(IShakespeareTranslateService), typeof(ShakespeareTranslateService));
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

			app.UseCors(CorsPolicy);

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
