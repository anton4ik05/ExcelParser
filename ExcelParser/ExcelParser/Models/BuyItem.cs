using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExcelParser.Models
{
    /// <summary>
    /// Абстрактная закупка
    /// </summary>
    [Description("Описатель закупки товара.")]
    public class BuyItem
    {
        private DateTime _uploadAt;

        /// <summary>
        /// Дата ТТН в формате YYYYMMDD (ISO 8601)
        /// </summary>
        [Required]
        public string TtnDate { get; set; } = null!;

        /// <summary>
        /// Дата договора в формате YYYYMMDD (ISO 8601)
        /// </summary>
        [Required]
        public string ContractDate { get; set; } = null!;

        /// <summary>
        /// Дата процедуры закупки (вскрытия конвертов) в формате YYYYMMDD (ISO 8601)
        /// </summary>
        public string ProcDate { get; set; } = null!;

        /// <summary>
        /// Дата прихода на склад в формате YYYYMMDD (ISO 8601)
        /// </summary>
        [Required]
        public string ReceiptDate { get; set; } = null!;

        /// <summary>
        /// Дата размещения объявления о процедуре закупки в формате YYYYMMDD (ISO 8601)
        /// </summary>
        public string BuyProcAnnounceDate { get; set; } = null!;

        /// <summary>
        /// УНП контрагента
        /// </summary>
        [Required]
        public string Unp { get; set; } = null!;

        /// <summary>
        /// Код единицы измерения (Справочник Единицы измерения, колонка Обозначение)
        /// </summary>
        [Required]
        public string Unit { get; set; } = null!;

        /// <summary>
        /// Наименование товара
        /// </summary>
        [Required]
        public string ProductName { get; set; } = null!;

        /// <summary>
        /// Код ЕК ТМЦ
        /// </summary>
        [Required]
        public string EkCode { get; set; } = null!;

        /// <summary>
        /// Код организации (Справочник Организации)
        /// </summary>
        [Required]
        public string EnterpriseCode { get; set; } = null!;

        /// <summary>
        /// Количество единиц товара
        /// </summary>
        [Required]
        public decimal Count { get; set; }

        /// <summary>
        /// Цена за единицу товара с учетом НДС в белорусских рублях
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Код условия доставки (справочник Условия доставки, колонка Код)
        /// </summary>
        [Required]
        public string DeliverCode { get; set; } = null!;

        /// <summary>
        /// Номер ТТН
        /// </summary>
        [Required]
        public string TtnNum { get; set; } = null!;

        /// <summary>
        /// Номер договора
        /// </summary>
        [Required]
        public string ContractNum { get; set; } = null!;

        /// <summary>
        /// Поставщик
        /// </summary>
        [Required]
        public string Provider { get; set; } = null!;

        /// <summary>
        /// Код источника финансирования (справочник Источники финансирования, колонка Код)
        /// </summary>
        [Required]
        public string FinanceCode { get; set; } = null!;

        /// <summary>
        /// Изготовитель
        /// </summary>
        public string Manufacturer { get; set; } = null!;

        /// <summary>
        /// Код страны изготовления (справочник Страны, колонка Код)
        /// </summary>
        [Required]
        public string CountryCode { get; set; } = null!;

        /// <summary>
        /// Код нормативного документа (справочник Нормативные документы, колонка Код)
        /// </summary>
        [Required]
        public int DocNum { get; set; }

        /// <summary>
        /// Код вида процедуры (справочник Виды процедур, колонка Код)
        /// </summary>
        [Required]
        public string ProcKindCode { get; set; } = null!;

        /// <summary>
        /// Номер процедуры
        /// </summary>
        public string ProcNum { get; set; } = null!;

        /// <summary>
        /// Код организатора процедуры (справочник Типы организаторов процедур, колонка Код)
        /// </summary>
        [Required]
        public int ProcOrgCode { get; set; }

        /// <summary>
        /// Количество участников
        /// </summary>
        public int? MemberCount { get; set; }

        /// <summary>
        /// Количество жалоб участников
        /// </summary>
        public int? MemberComplaintCount { get; set; }

        /// <summary>
        /// Тип победителя (1 - производитель, 2 - сбытовая организация, 3 - прочие)
        /// </summary>
        [Required]
        [Range(1, 3, ErrorMessage = "Неверный тип победителя (1 - производитель, 2 - сбытовая организация, 3 - прочие)")]
        public int WinnerType { get; set; }

        /// <summary>
        /// Условия оплаты (1 - предоплата, 2 - аванс, 3 - по факту поставки)
        /// </summary>
        [Required]
        [Range(1, 3, ErrorMessage = "Неверное условие оплаты (1 - предоплата, 2 - аванс, 3 - по факту поставки)")]
        public int PaymentType { get; set; }

        /// <summary>
        /// Код объекта обеспечения (справочник Объекты обеспечения, колонка Код)
        /// </summary>
        [Required]
        public int EnsuringObject { get; set; }

        /// <summary>
        /// Месяц загрузки пакета
        /// </summary>
        public int PackageMonth { get; set; }

        /// <summary>
        /// Год загрузки пакета
        /// </summary>
        public int PackageYear { get; set; }

        /// <summary>
        /// Код РУП. Создается на случай сбора нанных с филиалов
        /// </summary>
        [Required]
        public string RupCode { get; set; } = null!;

        /// <summary>
        /// Время загрузки пакета
        /// </summary>
        public DateTime UploadAt
        {
            get => _uploadAt;
            set => _uploadAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public bool IsHidden { get; set; }
    }
}