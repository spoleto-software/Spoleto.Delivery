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

The main interface, `IDeliveryService`, serves as an abstraction layer for the delivery of goods.  
It includes all the necessary methods for work with delivery providers, such as getting available tariffs, creating and deleting delivery orders, and others.

### DeliveryProvider

Each delivery provider must implement the `IDeliveryProvider` interface.

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
            FromLocation = new() { ProviderLocationCode = "270" },
            ToLocation = new() { ProviderLocationCode = "44" },
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
                ProviderLocationCode = "44",
                FiasId = Guid.Parse("0c5b2444-70a0-4932-980c-b4dc0d3f02b5"),
                Address = "ул. Блюхера, 32"
            },
            TariffCode = tariffs.First().Code,
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

## Spoleto.AddressResolver

[**Spoleto.AddressResolver**](https://github.com/spoleto-software/Spoleto.AddressResolver) is a library for parsing textual representations of addresses. It is designed to break down an address into its components, such as city, street, house number, fias, kladr and postal code.  

This library is used in the following code:

1. MasterPost provider to parse textual representations of an address to get a city Fias identifier, if it is not provided.
2. Cdek provider in the GetDeliveryPoints method for the same reason.

## Callbacks

Also the solution provides demo examples of implementation of services for updating delivery order statuses.

### Spoleto.Delivery.Callback.Cdek

Web Api callback service for **[Cdek webhooks](https://api-docs.cdek.ru/29924139.html)**:  

https://github.com/spoleto-software/Spoleto.Delivery/tree/main/src/Callbacks/Spoleto.Delivery.Callback.Cdek


### Spoleto.Delivery.Callback.MasterPost

Windows service to check delivery order statuses from MasterPost Web service with a specified frequency:  

https://github.com/spoleto-software/Spoleto.Delivery/tree/main/src/Callbacks/Spoleto.Delivery.Callback.MasterPost

