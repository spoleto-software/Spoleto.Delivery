using Spoleto.Delivery.Providers.Cdek;

namespace Spoleto.Delivery.Tests.Providers
{
    public class CdekTests //: BaseTest
    {
        private CdekProvider _provider;

        [OneTimeSetUp]
        public void Initialize()
        {
            _provider = new CdekProvider();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            _provider.Dispose();
        }

        [Test]
        public async Task GetTariffs()
        {
            // Arrange
            var tariffRequest = new Delivery.TariffRequest
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
                ]
            };

            // Act
            var tariff = await _provider.GetTariffsAsync(tariffRequest);

            // Assert
            Assert.That(tariff, Is.Not.Null);
        }
    }
}
