using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Json dönerken camel case özelliði pascal case olarak deðiþtirildi.
builder.Services.AddMvc(setupAction =>
{
    setupAction.EnableEndpointRouting = false;
}).AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
    jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

/*Bussiness katmanýndaki classlar otomatik olarak enjecte edilir.*/
var allProviderTypes = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies()
    .Select(a => System.Reflection.Assembly.Load(a)).SelectMany(t => t.GetTypes())
    .Where(t => t.Namespace != null);

foreach (var intfc in allProviderTypes.Where(t => t.IsInterface && t.Namespace.Contains("Inta.Turizm.Business")))
{
    var impl = allProviderTypes.FirstOrDefault(c => c.IsClass && intfc.Name.Substring(1) == c.Name);
    if (impl != null) builder.Services.AddScoped(intfc, impl);
}
/*Bussiness katmanındaki classlar otomatik olarak enjecte edilir.*/


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
