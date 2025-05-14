using Bll;
using Ibll;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy("all", a => a.AllowAnyHeader()
.AllowAnyMethod().AllowAnyOrigin()));
//dal
builder.Services.AddScoped<Idal.IdalCategory, Dal.Category_dal>();
builder.Services.AddScoped<Idal.IdalCompany, Dal.Company_Dal>();
builder.Services.AddScoped<Idal.IdalOrder, Dal.Order_dal>();
builder.Services.AddScoped<Idal.IdalCustomer, Dal.Customer_dal>();
builder.Services.AddScoped<Idal.IdalOrderDetails, Dal.Orders_detail_dal>();
builder.Services.AddScoped<Idal.IdalProduct, Dal.Product_dal>();
//bll 
builder.Services.AddScoped<Ibll.IcategoryBll, Bll.Category_Bll>();
builder.Services.AddScoped<Ibll.ICompanyBll, Bll.Company_Bll>();
builder.Services.AddScoped<Ibll.IOrdersDetailBll, Bll.Order_details_Bll>();
builder.Services.AddScoped<Ibll.IorderBll, Bll.Order_Bll>();
builder.Services.AddScoped<Ibll.IproductBll, Bll.Product_Bll>();
builder.Services.AddScoped<Ibll.ICustomerBll, Bll.Customer_Bll>();


// הוספת מדיניות CORS
builder.Services.AddCors(x => x.AddPolicy("all", a =>
    a.AllowAnyHeader() // מאפשר כותרות מכל בקשה
    .AllowAnyMethod() // מאפשר שיטות HTTP מכל בקשה (GET, POST, וכו')
    .AllowAnyOrigin())); // מאפשר כל מקור לגשת ל-API


var app = builder.Build();
app.UseStaticFiles();
app.UseCors("all");

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
