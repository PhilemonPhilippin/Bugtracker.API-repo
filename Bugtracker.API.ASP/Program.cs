using Bugtracker.API.ADO;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Services;
using Bugtracker.API.DAL.Interfaces;
using Bugtracker.API.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config injection
builder.Services.AddTransient<Connection>((service) =>
{
    return new Connection(builder.Configuration.GetConnectionString("CockxConnectionString"));
});

// DAL
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
// BLL
builder.Services.AddTransient<IMemberService, MemberService>();

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
