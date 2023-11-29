using signalr.Hubs;
using signalr.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IVoteManager,VoteManager>();
builder.Services.AddSignalR();
builder.Logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.None);
builder.Logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.None);
//builder.Host.ConfigureLogging(logging =>
//{
//    logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Trace);
//    logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Trace);
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/chatHub");
app.MapHub<ViewHub>("/hubs/view");
app.MapHub<StringToolsHub>("/hubs/stringtools");
app.MapHub<ColorHub>("/hubs/color");
app.MapHub<VoteHub>("/hubs/vote");
app.Run();
