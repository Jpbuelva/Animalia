using AutoMapper;
using Domain.Service.Interfaces;
using Domain.Service.Service;
using Infraestructure.Core.Context;
using Infraestructure.Core.Interfaces;
using Infraestructure.Core.Repositories;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Entity.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Application.WebApi
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
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddDbContext<ContextSql>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("animaliaConection")));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserToRolService, UserToRolService>();
            services.AddTransient<IRolService, RolService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application.WebApi", Version = "v1" });
            });
            //
            var mapperConfing = new MapperConfiguration(m =>
             {
                 m.AddProfile(new AutomapperProfile());
             });
            IMapper mapper = mapperConfing.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application.WebApi v1"));
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
