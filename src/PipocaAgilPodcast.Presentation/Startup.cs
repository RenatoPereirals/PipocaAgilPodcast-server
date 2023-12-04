using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Interfaces.ContractsServices;
using PipocaAgilPodcast.Mapping.UserMapping;
using PipocaAgilPodcast.Persistence;
using PipocaAgilPodcast.Services.Implementations;
using PipocaAgilPodcast.Persistence.Models;

namespace PipocaAgilPodcast.Presentation
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
            services.AddAutoMapper(typeof(UserToUserDTOMapper));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepositoryPesistence, RepositoryPesistence>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepositoryPesistence, RepositoryPesistence>();


            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

                services.AddDbContext<PipocaAgilPodcastDbContext>(context =>
                    context.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PipocaAgilPodcast.Presentation", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PipocaAgilPodcast.Presentation v1"));
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