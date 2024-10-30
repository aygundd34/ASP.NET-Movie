using MoviePresentationLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// HttpClient'i DI container'a ekleme
builder.Services.AddHttpClient<MovieApiAdapter>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5174");
});

// MovieApiAdapter'ı DI container'a ekleme
builder.Services.AddScoped<MovieApiAdapter>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Development ortamında olmayanlar için hata sayfası ve HSTS ayarları
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Statik dosyaları (CSS, JS vs.) servis eder

app.UseRouting();
app.UseAuthorization();

// Presentation Layer için Route tanıması
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// API için Route tanımları
app.MapControllerRoute(
    name: "api",
    pattern: "api/{controller=Movies}/{action=Index}/{id?}"); 

app.Run();