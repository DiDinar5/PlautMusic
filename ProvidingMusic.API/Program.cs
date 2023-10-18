using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProvidingMusic.API.Controllers;
using ProvidingMusic.BusinessLogic.Services;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Database.Repositories;
using ProvidingMusic.DataBase.AutoMapper;
using ProvidingMusic.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDBContext>(opt=>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaulConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//FluentAPI

builder.Services.AddScoped<ApplicationDBContext>();

builder.Services.AddScoped<IBandRepository, BandRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericRandomRepository<>), typeof(GenericRandomRepository<>));
builder.Services.AddScoped(typeof(IGenericSearchByNameRepository<>), typeof(GenericSearchByNameRepository<>));

builder.Services.AddScoped<IBandService, BandService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IGroupMemberService, GroupMemberService>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped(typeof(IGenericRandomService<>), typeof(GenericRandomService<>));
builder.Services.AddScoped(typeof(IGenericSearchByNameService<>), typeof(GenericSearchByNameService<>));



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
