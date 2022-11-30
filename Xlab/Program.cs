using BL;
using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DataBase Configuring
var connctionString = builder.Configuration.GetConnectionString("Defualt");
builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(connctionString));
#endregion


#region Services Configuring
builder.Services.AddScoped<IInvoiceService, InvoiceServices>();
#endregion



#region AutoMappper Configuring
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
#endregion


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
