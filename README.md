# sentryMonitor

```
public static IHostBuilder CreateHostBuilder(string[] args) =>
  Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
      {
          // Add the following line:
          webBuilder.UseSentry(o =>
          {
              o.Dsn = "https://a8c71b2e143c8dd8b3f52c9a70753b79@sentry.hamravesh.com/5734";
              // When configuring for the first time, to see what the SDK is doing:
              o.Debug = true;
              // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
              // We recommend adjusting this value in production.
              o.TracesSampleRate = 1.0;
          });
      });
```
