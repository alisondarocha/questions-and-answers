using Microsoft.EntityFrameworkCore;
using Q.A.__social_network.Commands;
using Q.A.__social_network.Data;
using Q.A.__social_network.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Social_NetworkContext>(options =>
{
    options.UseMySql(
        "server=localhost; port= 3306; initial catalog= Q.A.Social_Network_db; uid= root; pwd= initial1234",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")
);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();      

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

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo QuestionPost Api");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
