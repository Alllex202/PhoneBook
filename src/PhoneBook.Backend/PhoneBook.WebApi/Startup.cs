using System.Reflection;
using PhoneBook.Application;
using PhoneBook.Application.Common.Mapping;
using PhoneBook.Application.Interfaces;
using PhoneBook.Persistence;
using PhoneBook.WebApi.Middleware;

namespace PhoneBook.WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IPhoneBookDBContext).Assembly));
        });

        services.AddApplication();
        services.AddPersistence(Configuration);
        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        services.AddSwaggerGen(config =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            config.IncludeXmlComments(xmlPath);
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(config =>
        {
            config.RoutePrefix = string.Empty;
            config.SwaggerEndpoint("swagger/v1/swagger.json", "PhoneBook API");
        });

        app.UseCustomExceptionHandler();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}