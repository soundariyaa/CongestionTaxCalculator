using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Handler.Interfaces;
using TaxCalculator.Handler.Implementations;


var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<ICongestionTaxCalculator, CongestionTaxCalculator>();
        
    })
    .Build();

     

host.Run();
