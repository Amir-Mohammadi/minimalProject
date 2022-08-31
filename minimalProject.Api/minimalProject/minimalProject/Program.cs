using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using minimalProject.Core;
using minimalProject.Core.Data;
using minimalProject.Frameworks.Autofac;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options => options.AddPolicy(name: "minimalProjectOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    var currentAssembly = Assembly.GetExecutingAssembly();

    builder.RegisterAssemblyTypes(currentAssembly)
        .AssignableTo<IScopedDependency>()
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

    builder.RegisterAssemblyTypes(currentAssembly)
        .AssignableTo<ITransientDependency>()
        .AsImplementedInterfaces()
        .InstancePerDependency();

    builder.RegisterAssemblyTypes(currentAssembly)
        .AssignableTo<ISingletonDependency>()
        .AsImplementedInterfaces()
        .SingleInstance();

    builder.RegisterGeneric(typeof(Repository<>))
        .As(typeof(IRepository<>))
        .InstancePerLifetimeScope();


});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("minimalProjectOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


