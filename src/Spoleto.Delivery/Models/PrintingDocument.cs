namespace Spoleto.Delivery
{
    /// <summary>
    /// The printed form of the delivery order.
    /// </summary>
    public record PrintingDocument
    {
        public PrintingDocument(byte[] data, DocumentFormat format, string? name = null)
        {
            Data = data;
            Format = format;
            Name = name;
        }

        public byte[] Data { get; }

        public DocumentFormat Format { get; }

        public string? Name { get; }
    }
}