using Sentry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseSentry(o=>
{
    o.Dsn = "https://a8c71b2e143c8dd8b3f52c9a70753b79@sentry.hamravesh.com/5734";
    // When configuring for the first time, to see what the SDK is doing:
    o.Debug = true;
    // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
    // We recommend adjusting this value in production.
    o.TracesSampleRate = 1.0;
});

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

app.UseHttpsRedirection();

app.UseSentryTracing();

app.MapGet("/TestSentry", () =>
{
    SentrySdk.CaptureMessage("Hello Sentry.");
    return "OK";
})
.WithName("TestSentry")
.WithOpenApi();

app.Run();
