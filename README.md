# Spoleto.Delivery

[![](https://img.shields.io/github/license/spoleto-software/Spoleto.Delivery)](https://github.com/spoleto-software/Spoleto.Delivery/blob/main/LICENSE)
[![](https://img.shields.io/nuget/v/Spoleto.Delivery)](https://www.nuget.org/packages/Spoleto.Delivery/)
![Build](https://github.com/spoleto-software/Spoleto.Delivery/actions/workflows/ci.yml/badge.svg)

**Spoleto.Delivery** is a comprehensive solution designed to integrate delivery functionality into your .NET applications. This project provides a maintainable architecture that simplifies interaction with various delivery providers (e.g., Cdek, MasterPost).  
This project supports .NET Standard 2.0, .NET 7, and .NET 8.

https://github.com/spoleto-software/Spoleto.Delivery

## Features

- **Abstraction Layer**: Simplifies the integration of delivery services by providing a unified interface.
- **Multiple Providers**: Supports various delivery providers, allowing you to switch or combine them easily.
- **Async Support**: Fully supports asynchronous operations for improved performance.

## Quick setup

Begin by installing the package through the [NuGet](https://www.nuget.org/packages/Spoleto.Delivery/) package manager with the command:  
``Install-Package Spoleto.Delivery``.

## Usage

### Main Interface

The main interface, `IDeliveryService`, serves as an abstraction layer for the delivery of goods. Below is a sample implementation:

```csharp
namespace Spoleto.Delivery
{
    public interface IDeliveryService
    {
        IEnumerable<IDeliveryProvider> Providers { get; }
        IDeliveryProvider DefaultProvider { get; }

        List<City> GetCities(CityRequest cityRequest);
        List<City> GetCities(string providerName, CityRequest cityRequest);
        List<City> GetCities(DeliveryProviderName providerName, CityRequest cityRequest);
        List<City> GetCities(IDeliveryProvider provider, CityRequest cityRequest);
        Task<List<City>> GetCitiesAsync(CityRequest cityRequest);
        Task<List<City>> GetCitiesAsync(string providerName, CityRequest cityRequest);
        Task<List<City>> GetCitiesAsync(DeliveryProviderName providerName, CityRequest cityRequest);
        Task<List<City>> GetCitiesAsync(IDeliveryProvider provider, CityRequest cityRequest);

        List<Tariff> GetTariffs(TariffRequest tariffRequest);
        List<Tariff> GetTariffs(string providerName, TariffRequest tariffRequest);
        List<Tariff> GetTariffs(DeliveryProviderName providerName, TariffRequest tariffRequest);
        List<Tariff> GetTariffs(IDeliveryProvider provider, TariffRequest tariffRequest);
        Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest);
        Task<List<Tariff>> GetTariffsAsync(string providerName, TariffRequest tariffRequest);
        Task<List<Tariff>> GetTariffsAsync(DeliveryProviderName providerName, TariffRequest tariffRequest);
        Task<List<Tariff>> GetTariffsAsync(IDeliveryProvider provider, TariffRequest tariffRequest);

        List<AdditionalService> GetAdditionalServices(Tariff tariff);
        List<AdditionalService> GetAdditionalServices(string providerName, Tariff tariff);
        List<AdditionalService> GetAdditionalServices(DeliveryProviderName providerName, Tariff tariff);
        List<AdditionalService> GetAdditionalServices(IDeliveryProvider provider, Tariff tariff);
        Task<List<AdditionalService>> GetAdditionalServicesAsync(Tariff tariff);
        Task<List<AdditionalService>> GetAdditionalServicesAsync(string providerName, Tariff tariff);
        Task<List<AdditionalService>> GetAdditionalServicesAsync(DeliveryProviderName providerName, Tariff tariff);
        Task<List<AdditionalService>> GetAdditionalServicesAsync(IDeliveryProvider provider, Tariff tariff);

        DeliveryOrder CreateDeliveryOrder(DeliveryOrderRequest deliveryOrderRequest);
        DeliveryOrder CreateDeliveryOrder(string providerName, DeliveryOrderRequest deliveryOrderRequest);
        DeliveryOrder CreateDeliveryOrder(DeliveryProviderName providerName, DeliveryOrderRequest deliveryOrderRequest);
        DeliveryOrder CreateDeliveryOrder(IDeliveryProvider provider, DeliveryOrderRequest deliveryOrderRequest);
        Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryOrderRequest deliveryOrderRequest);
        Task<DeliveryOrder> CreateDeliveryOrderAsync(string providerName, DeliveryOrderRequest deliveryOrderRequest);
        Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryProviderName providerName, DeliveryOrderRequest deliveryOrderRequest);
        Task<DeliveryOrder> CreateDeliveryOrderAsync(IDeliveryProvider provider, DeliveryOrderRequest deliveryOrderRequest);
    }
}
```

### DeliveryProvider

Each delivery provider must implement the `IDeliveryProvider` interface:

```csharp
namespace Spoleto.Delivery.Providers
{
    public interface IDeliveryProvider
    {
        string Name { get; }
        List<City> GetCities(CityRequest cityRequest);
        Task<List<City>> GetCitiesAsync(CityRequest cityRequest);
        List<Tariff> GetTariffs(TariffRequest tariffRequest);
        Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest);
        List<AdditionalService> GetAdditionalServices(Tariff tariff);
        Task<List<AdditionalService>> GetAdditionalServicesAsync(Tariff tariff);
        DeliveryOrder CreateDeliveryOrder(DeliveryOrderRequest deliveryOrderRequest);
        Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryOrderRequest deliveryOrderRequest);
    }
}
```

DeliveryProvider is the underlying mechanisms that enable the actual delivery functionality. When you incorporate Spoleto.Delivery into your application, it's mandatory to install at least one of the available delivery providers.

The providers come as pre-configured NuGet packages:

- **[Spoleto.Delivery.Cdek](https://www.nuget.org/packages/Spoleto.Delivery.Cdek/)**: Delivery via CDEK https://www.cdek.ru/; 
- **[Spoleto.Delivery.MasterPost](https://www.nuget.org/packages/Spoleto.Delivery.MasterPost/)**: Delivery via MasterPost https://mplogistics.ru/; 

## Example

Here is a simple example to demonstrate how to use Spoleto.Delivery in your project:

```csharp
using Spoleto.Delivery;
using Spoleto.Delivery.Providers;

public class Example
{
    public async Task Run()
    {
        var deliveryService = new DeliveryServiceFactory()
                                .WithOptions(x => x.DefaultProvider == CdekProvider.ProviderName)
                                .AddProvider(new CdekProvider(cdekOptions))
                                .AddProvider(new MasterPostProvider(masterPostOptions))
                                .Build();

        var cityRequest = new CityRequest
        {
            Name = "Москва"
        };
        var cities = await deliveryService.GetCitiesAsync(cityRequest);


        var tariffRequest = new TariffRequest
        {
            FromLocation = new() { Code = "270" },
            ToLocation = new() { Code = "44" },
            Packages =
            [
                new()
                {
                    Weight = 4000,
                    Height = 10,
                    Width = 10,
                    Length = 10
                }
            ],
        };
        var tariffs = await deliveryService.GetTariffsAsync(tariffRequest);
        

        var deliveryOrderRequest = new DeliveryOrderRequest
        {
            Type = OrderType.RegularDelivery,
            Comment = "Just another test order",
            FromLocation = new()
            {
                ProviderLocationCode = "44",
                Address = "пр. Ленинградский, д.4",
            },
            ToLocation = new()
            {
                Code = "44",
                FiasId = Guid.Parse("0c5b2444-70a0-4932-980c-b4dc0d3f02b5"),
                Address = "ул. Блюхера, 32"
            },
            NumTariffCode = tariffs.First().NumCode,
            Packages =
            [
                new()
                {
                    Number = "1",
                    Comment = "Test",
                    Weight = 1000,
                    Width = 10,
                    Height = 10,
                    Length = 10,
                },
            ],
            Sender = new()
            {
                Company = "Roga",
                Name = "Copyta",
                Email = "roga@copyta.com",
                Phones =
                [
                    new() { Number = "+71111111111" },
                ],
            },
            Recipient = new()
            {
                Company = "Ushi",
                Name = "Hvost",
                Email = "ushi@hvost.com",
                Phones =
                [
                    new() { Number = "+72222222222" },
                ],
            },
        };

        var order = await deliveryService.CreateDeliveryOrderAsync(deliveryOrderRequest);
        
        Console.WriteLine($"Order created with ID: {order.Uuid} and Number: {order.Number}");
    }
}
```

## Dependency Injection

To integrate Spoleto.Delivery into Microsoft Dependency injection framework, you should utilize the [**Spoleto.Delivery.Extensions**](https://www.nuget.org/packages/Spoleto.Delivery.Extensions/) NuGet package. This package provides an extension method for the ``IServiceCollection`` interface, which register the DeliveryService as a scoped service.

The extentions for Delivery providers come as pre-configured NuGet packages:

- **[Spoleto.Delivery.Extensions.Cdek](https://www.nuget.org/packages/Spoleto.Delivery.Extensions.Cdek/)**: CDEK registration; 
- **[Spoleto.Delivery.Extensions.MasterPost](https://www.nuget.org/packages/Spoleto.Delivery.Extensions.MasterPost/)**: MasterPost registration.

After ensuring that the ``Spoleto.Delivery.Extensions`` package with at least one Delivery provider package are installed from NuGet, you can proceed with the registration of Spoleto.Delivery within the ``Startup.cs`` or your DI configuration file in the following manner:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Other DI registrations...

    // Register Spoleto.Delivery as a scoped service:
    services.AddDelivery(MasterPostProvider.ProviderName)
        .AddMasterPost("MasterPost_IndividualClientNumber", "MasterPost_ApiKey", "MasterPost_ApiKey", "MasterPost_ServiceUrl")
        .AddCdek("Cdek_CliendId", "Cdek_ClientSecret", "Cdek_ServiceUrl");

    // Continue with the rest of your service configuration...
}

```

### Injecting the Delivery Service into Your Classes
Once Spoleto.Delivery has been registered with your Dependency Injection framework, you can facilitate the injection of the Delivery service into any class within your application.

Inject the ``IDeliveryService`` interface into the constructors of the classes where you want to use Delivery functionality:

```csharp
public class YourDeliveryClass
{
    private readonly ILogger<YourDeliveryClass> _logger;
    private readonly IDeliveryService _deliveryService;

    public YourDeliveryClass(ILogger<YourDeliveryClass> logger, IDeliveryService deliveryService)
    {
        _logger = logger;
        _deliveryService = deliveryService;
    }

    public async Task CreateDeliveryOrder(ModelRequest from, ModelRequest to, ModelData data)
    {
        // create a DeliveryOrderRequest
        var deliveryOrderRequest = CreateDeliveryOrderRequest(from, to, data);

        // create the delivery order using the default Delivery provider:
        var order = await _deliveryService.CreateDeliveryOrderAsync(deliveryOrderRequest);

        // create the delivery order using the specified Delivery provider:
        var order1 = await _deliveryService.CreateDeliveryOrderAsync(DeliveryProviderName.Cdek, deliveryOrderRequest);
        var order2 = await _deliveryService.CreateDeliveryOrderAsync(DeliveryProviderName.MasterPost, deliveryOrderRequest);

        // log the result:
        _logger.LogInformation("Order created with ID: {order.Uuid} and Number: {order.Number}", order.Uuid, order.Number);
    }
}
```