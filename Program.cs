using System.Text;
using api.Models;
using api.Services;
using Microsoft.IdentityModel.Tokens;
using Supabase;
var builder = WebApplication.CreateBuilder(args);
 


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAuthorization();

var bytes = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtSecret"]!);

builder.Services.AddAuthentication().AddJwtBearer(options =>{
    options.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =  new SymmetricSecurityKey(bytes),
        ValidAudience =  builder.Configuration["Authentication:ValidAudience"],
        ValidIssuer =builder.Configuration["Authentication:ValidIssuer"]
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // Replace with your frontend URL
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
 
var url = builder.Configuration["Supabase:Url"];
var key = builder.Configuration["Supabase:ApiKey"];


 
builder.Services.AddSingleton(sp =>
{
    var options = new SupabaseOptions { AutoRefreshToken = true };
    var client = new Client(url, key, options);
    client.InitializeAsync().Wait();
    return client;
});

builder.Services.AddScoped<SupabaseService>();

 
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
// app.MapGet("/getProduct/{id}", async (int id, Client client) =>
// {
//     var response = await client.From<Product>().Get();
//     var foundProduct = response.Models;

//      Console.WriteLine($"Response: {Newtonsoft.Json.JsonConvert.SerializeObject(response)}");
 
//     if (foundProduct is null)
//     {
//         return Results.NotFound($"Product with ID {id} not found., {response}, product {foundProduct}");
//     }

//     return Results.Ok(Newtonsoft.Json.JsonConvert.SerializeObject(foundProduct));
// }).RequireAuthorization();


 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
 
app.Run();
 