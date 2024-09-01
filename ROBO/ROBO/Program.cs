using ROBO.Models.Aplicacao;
using ROBO.Models.Dominio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar as dependências
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

//Configuração da rota padrão para iniciar no RoboController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Robo}/{action=Inicio}/{id?}");

app.Run();