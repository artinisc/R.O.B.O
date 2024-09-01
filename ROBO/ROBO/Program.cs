using ROBO.Models.Aplicacao;
using ROBO.Models.Dominio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar as depend�ncias
builder.Services.AddScoped<IRoboBecomexMapper, RoboBecomexMapper>();
builder.Services.AddScoped<IAplicControlaRoboBecomex, AplicControlaRoboBecomex>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Configura��o da rota padr�o para iniciar no RoboController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Robo}/{action=Inicio}/{id?}");

app.Run();