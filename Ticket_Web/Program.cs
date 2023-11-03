using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using System.Text;
using Ticket_Web;
using Ticket_Web.Data;
using Ticket_Web.Repository;
using Ticket_Web.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);


//Add Connetiont String
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("CS")));

//Add Respository Service

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketBookRepository, TicketBookRepository>();

builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//JWt Token authentication

//var appSettingSection = builder.Configuration.GetSection("AppSettings");
//builder.Services.Configure<AppSettings>(appSettingSection);
//var appSetting = appSettingSection.Get<AppSettings>();
//var key = Encoding.ASCII.GetBytes(appSetting.Secret);


//do short code below

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings").Get<AppSettings>().Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{

    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
