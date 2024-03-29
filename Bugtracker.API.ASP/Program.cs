using Bugtracker.API.ADO;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Services;
using Bugtracker.API.BLL.Tools;
using Bugtracker.API.DAL.Interfaces;
using Bugtracker.API.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Create bugtrackerapi variable for my cors
var BugtrackerWasmCorsPolicy = "_BugtrackerWasmCorsPolicy";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<JwtManager>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: BugtrackerWasmCorsPolicy,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7036")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("isConnected", policy => policy.RequireAuthenticatedUser());
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtToken").GetSection("secret").ToString())),
            ValidateIssuer = false,
            ValidIssuer = builder.Configuration.GetSection("JwtToken").GetSection("issuer").Value,
            ValidateAudience = false,
            ValidAudience = builder.Configuration.GetSection("JwtToken").GetSection("audience").Value
        };
    });

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config injection
builder.Services.AddTransient<Connection>((service) =>
{
    return new Connection(builder.Configuration.GetConnectionString("LaptopConnectionString"));
});

// DAL
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<IAssignRepository, AssignRepository>();
// BLL
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IAssignService, AssignService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use the cors policy - after routing but before authorization
app.UseCors(BugtrackerWasmCorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
