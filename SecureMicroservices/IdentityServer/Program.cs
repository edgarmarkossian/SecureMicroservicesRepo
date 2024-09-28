using IdentityServer;
using IdentityServerHost.Quickstart.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


//TODO integrate real database
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddTestUsers(TestUsers.Users)
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();

//TODO implement access denied page
