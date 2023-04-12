using System.Net;
using ASS_MVC.Service;
using ASS_MVC.Iservice;
using ASS_MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
/*builder.Services.AddSingleton(IProduct,Product);*/
builder.Services.AddControllersWithViews();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(1500);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePages(appError =>
{
    appError.Run(async Context =>
    {
        var respone = Context.Response;
        var code = respone.StatusCode;
        var content = $@"loi la {code} : {(HttpStatusCode)code};";
        await respone.WriteAsync(content);
    });
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");
    
});

app.Run();
