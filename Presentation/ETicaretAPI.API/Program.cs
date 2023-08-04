using FluentValidation.AspNetCore;
using OnionArchitecture.API.Middlewares;
using OnionArchitecture.Application;
using OnionArchitecture.Application.Utilities.Settings;
using OnionArchitecture.Application.Validators.Products;
using OnionArchitecture.Infrastructure;
using OnionArchitecture.Infrastructure.Services.Storage.Local;
using OnionArchitecture.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddStorage<LocalStorage>();

builder.Services.AddCors(option => option.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()));
builder.Services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.Services.SetServiceProvider();

//var a = app.Services.GetServices<ICommonRepository>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.UseCoreMiddlewares();

app.Run();
