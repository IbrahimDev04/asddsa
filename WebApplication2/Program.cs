using WebApplication2.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR()
    .AddJsonProtocol(options => {
        options.PayloadSerializerOptions.PropertyNamingPolicy = null;
    });
var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();

