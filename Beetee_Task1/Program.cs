using Beetee_Task.DAL.DataAccess;
using Beetee_Task.DAL.Interfaces;
using Beetee_Task.DAL.Repositories;


using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddDbContext<ApplicationDBContext>(
         options =>
         {
             options.UseSqlServer(builder.Configuration.
                 GetConnectionString("DefaultConnection"));
         });

builder.Services.AddTransient<IApplicationDbContext, ApplicationDBContext>();

builder.Services.AddScoped(typeof(IHRDataRepository), typeof(HRDataRepository));
builder.Services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
