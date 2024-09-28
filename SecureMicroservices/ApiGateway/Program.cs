using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var authenticationProviderKey = "IdentityApiKey";

builder.Services.AddAuthentication()
             .AddJwtBearer(authenticationProviderKey, x =>
             {
                 x.Authority = "https://localhost:5005"; // IDENTITY SERVER URL
                 //x.RequireHttpsMetadata = false;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = false
                 };
             });

builder.Services.AddOcelot();

builder.Configuration.AddJsonFile("ocelot.json");

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.UseOcelot();

app.Run();
