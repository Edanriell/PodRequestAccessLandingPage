using PodRequestAccessLandingPage.App;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(sp =>
	new HttpClient
	{
		BaseAddress = new Uri(builder.Configuration["BackendApiUrl"] ?? "https://localhost:7017/")
	});

builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", true);
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();