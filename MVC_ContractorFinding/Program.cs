using ServiceLayer;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddHttpClient<IDSLogin, DSLogin>();
builder.Services.AddHttpClient<IDScustomer, DScustomer>();
builder.Services.AddHttpClient<IDsContract,DsContract>();
builder.Services.AddHttpClient<IDSRegistration, DSRegistration>();
builder.Configuration.AddJsonFile("appsettings.json", optional:true);
builder.Services.Configure<APIDetails>(builder.Configuration.GetSection("APIDetails"));









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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
