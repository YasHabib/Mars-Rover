using Mars_Rover.Services;
using Mars_Rover.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
//builder.Services.AddHttpClient<IRoverFrontendServices, RoverFrontendServices>(c => c.BaseAddress= new Uri("https://localhost:2000/"));
//builder.Services.AddHttpClient<IRoverFrontendServices, RoverFrontendServices>(c => c.BaseAddress = new Uri("http://host.docker.internal:2000"));
builder.Services.AddHttpClient<IRoverFrontendServices, RoverFrontendServices>();





var app = builder.Build();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTM4MjQ1MkAzMjMwMmUzNDJlMzBjaGFUWEo2Wm4wNzZ1L0V5Z3FlMjNHQVFxVjZ0eTlDUGNYcFJEZDFsUVBRPQ==;Mgo DSMBaFt/QHRqVVhkVFpHaV1FQmFJfFBmRGlafVR0dUUmHVdTRHRcQl5hSX9QdUdnWHpXdH0=;Mgo DSMBMAY9C3t2VVhkQlFacldJXnxLeUx0RWFab196d1dMZF1BJAtUQF1hSn5QdEViWnxcdHVTRmZV;Mgo DSMBPh8sVXJ0S0J XE9AflRBQmFOYVF2R2BJflRzdl9CYUwxOX1dQl9gSX1RdkRgWn1acXJUTmk=;MTM4MjQ1NkAzMjMwMmUzNDJlMzBjeDhqTERnOG55djBYQUxvaktldjQ1bFZuMHV3N3NxSlU2emwvbEg2MlBJPQ==;NRAiBiAaIQQuGjN/V0Z WE9EaFtKVmBWfFRpR2NbfE5xflZEalhQVBYiSV9jS31TdUdjWHxdcnBUQGVcWA==;ORg4AjUWIQA/Gnt2VVhkQlFacldJXnxLeUx0RWFab196d1dMZF1BJAtUQF1hSn5QdEViWnxcdHVTQGJV;MTM4MjQ1OUAzMjMwMmUzNDJlMzBLZXRzaHNxOExaZ1RoTVdPdzg4akI2ZFpSZW5uRWQydGhudmhQSnNyRVYwPQ==;MTM4MjQ2MEAzMjMwMmUzNDJlMzBlZnM0OTJUSEI0ekVURlQxK2ZFOW80UlIvWTVKYWx2cStESlZTS1FjYnFZPQ==;MTM4MjQ2MUAzMjMwMmUzNDJlMzBUKzRJamdwb3pUVDhPeDFrbDJzajl4a3laSkU3OUswRjhtSXBiSjBZY3A0PQ==;MTM4MjQ2MkAzMjMwMmUzNDJlMzBOVUpmeHVtUDY4dXg3UHRTVDdDMThqODFDU1J0Y2RWay9mcjBtcWJsSThFPQ==;MTM4MjQ2M0AzMjMwMmUzNDJlMzBjaGFUWEo2Wm4wNzZ1L0V5Z3FlMjNHQVFxVjZ0eTlDUGNYcFJEZDFsUVBRPQ==");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
