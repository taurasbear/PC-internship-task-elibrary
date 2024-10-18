using Microsoft.EntityFrameworkCore;
using PCElibrary.Application;
using PCElibrary.Infrastructure;
using PCElibrary.Infrastructure.DbContext;
using PCElibrary.Infrastructure.Repositories;
using PCElibrary.Server.Mappings;
using PCElibrary.Server.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureInfrastructure();
builder.Services.ConfigureApplication();
builder.Services.AddControllers();
//builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("LibraryDb"));

//builder.Services.AddScoped<IBookRepository, BookRepository>();
//builder.Services.AddScoped<IBookService, BookService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
