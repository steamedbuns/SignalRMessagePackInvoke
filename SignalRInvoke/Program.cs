using SignalRInvoke.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR(
   hubOptions =>
   {
      hubOptions.MaximumReceiveMessageSize = 32 * 1024 * 1024;
      hubOptions.SupportedProtocols?.Remove("json");
      hubOptions.MaximumParallelInvocationsPerClient = 16;
   }).AddMessagePackProtocol();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/ChatHub");

app.Run();
