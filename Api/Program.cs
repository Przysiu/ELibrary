using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoreLayer.ServicesInterfaces;
using CoreLayer.Infrastructure;
using CoreLayer.EFInterfaces;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<LibraryDatabaseContext>(x => { x.UseSqlite(connectionString, z => z.MigrationsAssembly("Api")); });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBookRepository,LibraryDatabaseContext>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddTransient<IAuthorRepository, LibraryDatabaseContext>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBorrowingRepository, LibraryDatabaseContext>();
builder.Services.AddScoped<IBorrowingService, BorrowingService>();


//builder.Services.AddTransient<IBookRepository, LibraryDatabaseContext>();
//builder.Services.AddScoped<IBookService, BookService>();
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
