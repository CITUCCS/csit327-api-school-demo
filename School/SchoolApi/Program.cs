using SchoolApi.Context;
using SchoolApi.Repositories;
using SchoolApi.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Add header documentation in swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "School Enrollment API",
        Description = "This is the best API for School enrollements!",
        Contact = new OpenApiContact
        {
            Name = "Jhon Christian Ambrad",
            Url = new Uri("https://www.facebook.com/jca.kt")
        },
    });
    // Feed generated xml api docs to swagger
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


// Configure our services
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    // Trasient -> create new instance of DapperContext everytime.
    services.AddTransient<DapperContext>();
    // Configure Automapper
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    // Services
    services.AddScoped<ISchoolService, SchoolService>();
    services.AddScoped<IStudentService, StudentService>();
    services.AddScoped<IEnrollmentService, EnrollmentService>();
    // Repos
    services.AddScoped<ISchoolRepository, SchoolRepository>();
    services.AddScoped<IStudentRepository, StudentRepository>();
}