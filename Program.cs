using PruebaAnalisisDeImagen.Components;
//using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.ResponseCompression;
using System.Net;
using PruebaAnalisisDeImagen.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<ImageDataSharingService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BaseAddress"] ?? "https://localhost:5001") });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapPost("/upload", async ([FromForm] WebAssemblyTicket ticket,
    [FromServices] IWebHostEnvironment env) =>
{
    foreach (var file in ticket.Attachments)
    {
        // Save locally
        string safeFileName = WebUtility.HtmlEncode(file.FileName);
        var path = Path.Combine(env.ContentRootPath, "images", safeFileName);
        await using FileStream fs = new(path, FileMode.Create);
        await file.CopyToAsync(fs);

        // TODO: Save title, description, image reference to a database
    }
}).DisableAntiforgery();

app.Run();

class WebAssemblyTicket
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFileCollection Attachments { get; set; }
}