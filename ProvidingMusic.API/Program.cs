using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProvidingMusic.API.Controllers;
using ProvidingMusic.BusinessLogic.Services;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDBContext>(opt=>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaulConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IGroupMusicRepository, GroupMusicRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IAlbumRepository,  AlbumRepository>();
builder.Services.AddScoped<IGroupMemberRepository,GroupMemberRepository>();

builder.Services.AddScoped<IGroupMusicBLL, GroupMusicBLL>();
builder.Services.AddScoped<ISongBLL,SongBLL>();
builder.Services.AddScoped<IAlbumBLL,AlbumBLL>();
builder.Services.AddScoped<IGroupMemberBLL,GroupMemberBLL>();


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
