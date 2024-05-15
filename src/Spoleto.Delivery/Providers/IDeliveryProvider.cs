namespace Spoleto.Delivery.Providers
{
    /// <summary>
    /// The delivery provider for delivery of goods.
    /// </summary>
    public interface IDeliveryProvider
    {
        /// <summary>
        /// Gets the delivery provider unique name.
        /// </summary>
        string Name { get; }

        List<Tariff> GetTariffs(TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest);

        /// <summary>
        /// Gets the status of the specified delivery with the specified Id.
        /// </summary>
        /// <param name="id">The delivery Id.</param>
        /// <returns><see cref="DeliveryStatusResult"/> to indicate status result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
        DeliveryStatusResult GetStatus(string id);

        /// <summary>
        /// Async gets the status of the specified delivery with the specified Id.
        /// </summary>
        /// <param name="id">The delivery Id.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns><see cref="DeliveryStatusResult"/> to indicate status result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
        /// <exception cref="OperationCanceledException">Thrown when <paramref name="cancellationToken"/> is canceled.</exception>
        Task<DeliveryStatusResult> GetStatusAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends the delivery.
        /// </summary>
        /// <param name="goodsDelivery">The delivery to be send</param>
        /// <returns><see cref="DeliverySendingResult"/> to indicate sending result.</returns>
        DeliverySendingResult Send(GoodsDelivery goodsDelivery);

        /// <summary>
        /// Async sends the delivery.
        /// </summary>
        /// <param name="GoodsDelivery">The delivery to be send</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns><see cref="DeliverySendingResult"/> to indicate sending result.</returns>
        /// <exception cref="OperationCanceledException">Thrown when <paramref name="cancellationToken"/> is canceled.</exception>
        Task<DeliverySendingResult> SendAsync(GoodsDelivery GoodsDelivery, CancellationToken cancellationToken = default);
    }
}
