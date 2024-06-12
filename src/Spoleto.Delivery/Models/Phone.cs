namespace Spoleto.Delivery
{
    public record Phone
    {
        /// <summary>
        /// Номер телефона. 
        /// Должен передаваться в международном формате: код страны (для России +7) и сам номер (10 и более цифр).
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дополнительная информация (добавочный номер).
        /// </summary>
        public string? Additional { get; set; }
    }
}
