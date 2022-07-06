using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PhoneContext>(options => options.UseSqlServer(connection));

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/phones", async (PhoneContext db) => await db.Phones.ToListAsync());

app.MapGet("/api/phones/{id:int}", async (int id, PhoneContext db) =>
{

    Phone? phone = await db.Phones.FirstOrDefaultAsync(u => u.Id == id);
    if (phone == null) return Results.NotFound(new { message = "Запись не найдена" });
    return Results.Json(phone);
});
app.MapDelete("/api/phones/{id:int}", async (int id, PhoneContext db) =>
{

    Phone? phone = await db.Phones.FirstOrDefaultAsync(u => u.Id == id);
    if (phone == null) return Results.NotFound(new { message = "Запись не найдена" });
    db.Phones.Remove(phone);
    await db.SaveChangesAsync();
    return Results.Json(phone);
});
app.MapPost("/api/phones", async (Phone phone, PhoneContext db) =>
{
    await db.Phones.AddAsync(phone);
    await db.SaveChangesAsync();
    return phone;
});
app.MapPut("/api/phones", async (Phone phoneData, PhoneContext db) =>
{

    var phone = await db.Phones.FirstOrDefaultAsync(u => u.Id == phoneData.Id);
    if (phone == null) return Results.NotFound(new { message = "Пользователь не найден" });
    phone.Price = phoneData.Price;
    phone.Name = phoneData.Name;
    await db.SaveChangesAsync();
    return Results.Json(phone);
});


app.Run();
