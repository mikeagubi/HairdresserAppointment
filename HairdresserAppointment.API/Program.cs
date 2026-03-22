using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.Services;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));



builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<DayOffService>();
builder.Services.AddScoped<HairdresserService>();
builder.Services.AddScoped<PromotionService>();
builder.Services.AddScoped<TreatmentService>();
builder.Services.AddScoped<WorkingHourService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
