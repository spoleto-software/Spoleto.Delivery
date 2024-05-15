namespace Spoleto.Delivery
{
    public interface IOptions
    {
        /// <summary>
        /// Checks that all the settings within the options are configured properly.
        /// </summary>
        void Validate();
    }
}
