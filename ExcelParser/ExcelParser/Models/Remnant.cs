namespace ExcelParser.Models
{
    /// <summary>
    /// Отстаток
    /// </summary>
    public class Remnant
    {
        private string _ekCode = null!;
        private decimal _amount;
        private string _receiptDate = null!;

        /// <summary>
        /// Код ЕК ТМЦ. (справочник ЕК ТМЦ, колонка Код)
        /// </summary>
        public string EkCode
        {
            get => _ekCode;
            set => _ekCode = value.Trim();
        }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Amount
        {
            get => _amount;
            set => _amount = decimal.Round(value, 2);
        }

        /// <summary>
        /// Количество
        /// </summary>
        public decimal Count { get; set; }

        /// <summary>
        /// Дата прихода на склад
        /// </summary>
        public string ReceiptDate
        {
            get => _receiptDate;
            set => _receiptDate = value.Trim();
        }

        /// <summary>
        /// Атрибуты 
        /// </summary>
        public RemnantAttribute Attributes { get; set; } = null!;
    }
}