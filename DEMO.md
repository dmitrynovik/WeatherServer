## Add OpenMeteo

## Change Controller Get

## Add Health Endpoint
```
 app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Add management endpoints into pipeline like this
                endpoints.Map<HealthEndpoint>();
            });
```

## Helm Chart Sequence
TODO