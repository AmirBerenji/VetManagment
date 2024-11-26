using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetManageApi.Data;
using PetManageApi.Entities;
using PetManageApi.Helper;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<PetManageDbContext>(opt => 
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Defualtconnection")).EnableSensitiveDataLogging(); 
});

builder.Services.AddIdentityCore<AppUser>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false; // Customize password options
})
.AddRoles<IdentityRole>() // Add support for roles
.AddEntityFrameworkStores<PetManageDbContext>() // Use Entity Framework for user and role stores
.AddRoleManager<RoleManager<IdentityRole>>() // Register RoleManager<IdentityRole>
.AddSignInManager<SignInManager<AppUser>>();


string key = "78319B5F-6868-4B28-B08C-98564A293F38";
var issuer = "http://localhost:7001";
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var Key = Encoding.UTF8.GetBytes(key);
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });





builder.Logging.AddConsole();

var app = builder.Build();


app.UseAuthentication(); // This need to be added	
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

try
{
    await DataInitializer.InitDbAsync(app);
}
catch (Exception e)
{

    Console.WriteLine(e);
}

app.Run();
