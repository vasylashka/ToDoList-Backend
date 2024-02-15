using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Contracts_Mapping;
using ToDoList.API.Middlewares;
using ToDoList.Persistance;
using ToDoList.Persistance.Repository.Interfaces.Base;
using ToDoList.Persistance.Repository.Realizations.Base;
using ToDoList.Services.DTOs_mapping;
using ToDoList.Services.Services.Interfaces;
using ToDoList.Services.Services.Realizations;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ToDoListDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddSingleton(new MapperConfiguration(x =>
{
    x.AddProfiles(new Profile[]
    {
        new ContractsToDtoMapping(),
        new DtoToEntityMapper()
    });
}).CreateMapper());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(setup =>
{
    setup.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
