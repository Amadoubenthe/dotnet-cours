using Microsoft.OpenApi.Models;
using System.Reflection;
using nameProject.webApi.logging;
using NLog;
using Microsoft.AspNetCore.Cors;
using univassurence2.dataAccess.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using nameProject.webApi.Auth;
using Microsoft.AspNetCore.Identity;
// using nameProject.webApi.Auth.AuthDbcontext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(
    c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo
      {
        Title = "Gestion de souscription",
        Version = "1.0.0",
        Description = "<h2> <strong> Projet pour la gestion de souscription dans le cadre dans une assurance de gestion des sinistres </strong> </h2>"
      });
      string nomFichier = $"{Assembly.GetExecutingAssembly()?.GetName().Name}.xml";
      string FichierXml = Path.Combine(AppContext.BaseDirectory, nomFichier);
      c.IncludeXmlComments(FichierXml);
    }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<Ilog, Log>();

builder.Services.AddDbContext<SouscriptionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SouscriptionDbContext")));
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(auth =>
{
  auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
});

builder.Services.AddAuthentication(options =>
            {
              options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                  options.SaveToken = true;
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://localhost:5272",
                    ValidIssuer = "http://localhost:5272",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"))
                  };
                });

// string CorsOrigin = builder.Configuration.GetSection("CorsOrigin").Get<string>();

// string[] CorsOrigins = CorsOrigin.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

// builder.Services.AddSwaggerGen(c =>
// {
//   c.SwaggerDoc("v1", new OpenApiInfo
//   {
//     Title = "Gestion de souscriptions",
//     Version = "1.0.0",
//     Description = "Projet de gestion de souscrition d'une assurance"
//   });

//   // string swaggerDoc = "swaggerDoc.xml";
//   string swaggerDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//   // string swaggerDocFilee = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";


//   string FichierXml = Path.Combine(AppContext.BaseDirectory, swaggerDocFile);

//   c.IncludeXmlComments(FichierXml);
// });





//string co = builder.Configuration.GetSection("CorsOrigin").Get<string>();
// string[] corsOrigin = co.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

// string CorsOrigin = builder.Configuration.GetSection("CorsOrigin").Get<string>();

// string[] CorsOrigins = CorsOrigin.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);



// // // Ajout cors
// builder.Services.AddCors(o =>
// {
//   o.AddPolicy("SouscriptionCors", p =>
//   {
//     p.WithOrigins(CorsOrigins);
//   });
// });

string PathFind = $"{Directory.GetCurrentDirectory()}/bin/Debug/net6.0/Nlog.config";

LogManager.LoadConfiguration(PathFind);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
  c.RoutePrefix = string.Empty;
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

// Appel cors
app.UseCors("SouscriptionCors");

app.MapControllers();

app.Run();
var host = new WebHostBuilder().UseIISIntegration().Build();
host.Run();


