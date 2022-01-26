using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Efcore;
using NLayer.Repository.Efcore.Repositories;
using NLayer.Repository.Efcore.Repositories.Abstract;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using NLayer.Service.Services.Abstract;
using System.Reflection;
using NLayer.Service.Validation;
using NLayer.API.Filters;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.MiddleWares;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using NLayer.API.AutofacModule;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidateFilterAttribute());

});

// API nin kendi döndüðü model filter'ý inaktif eder.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Fluent Validation Dahil Edildi
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidation>()); 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuration

//Cahce
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<NLayerDbContext>(X =>
{
    X.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
     {
         option.MigrationsAssembly(Assembly.GetAssembly(typeof(NLayerDbContext)).GetName().Name);
     });
});


builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new RepoServiceModule());
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Global Exception Handler
app.UseCustomExcepiton();

app.UseAuthorization();

app.MapControllers();

app.Run();
