using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

//  Si quieres seguir usando RazorPages para otras cosas, puedes dejar esto:
builder.Services.AddRazorPages();

var app = builder.Build();

//  Manejo de errores y HTTPS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

//  Sirve index.html automáticamente si van a "/"
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".tmj"] = "application/json";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseRouting();

// Si quieres mantener RazorPages para otras rutas
app.UseAuthorization();
app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.Run();
