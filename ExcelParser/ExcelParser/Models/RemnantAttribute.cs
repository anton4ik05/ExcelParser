using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable enable

namespace ExcelParser.Models
{
  [Description("Дополнительные атрибуты описания остатка")]
  public class RemnantAttribute
  {
    private string _name = null!;
    private string? _fullName;
    private string _unit = null!;
    private string _category = null!;
    private decimal _price;
    private string? _invoice;
    private string? _contractNum;
    private string? _contractDate;
    private string _enterpriseCode = null!;
    private string? _countryCode;
    private string _storagePlace = null!;

    /// <summary>
    /// Название продукта
    /// </summary>
    public string Name
    {
      get => _name;
      set => _name = value.Trim();
    }

    /// <summary>
    /// Полное название продукта
    /// </summary>
    public string? FullName
    {
      get => _fullName;
      set => _fullName = value?.Trim();
    }

    /// <summary>
    /// Код единицы измерения
    /// </summary>
    public string Unit
    {
      get => _unit;
      set => _unit = value.Trim();
    }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price
    {
      get => _price;
      set => _price = decimal.Round(value, 2);
    }

    /// <summary>
    /// Категория места хренения (справочник Категории запасов ТМЦ, колонка Код)
    /// </summary>
    public string Category
    {
      get => _category;
      set => _category = value.Trim();
    }

    /// <summary>
    /// Наименование места хранения
    /// </summary>
    public string StoragePlace
    {
      get => _storagePlace;
      set => _storagePlace = value.Trim();
    }

    /// <summary>
    /// Счет бухгалтерского учета
    /// </summary>
    public string? Invoice
    {
      get => _invoice;
      set => _invoice = value?.Trim();
    }

    /// <summary>
    /// Номер договора
    /// </summary>
    public string? ContractNum
    {
      get => _contractNum;
      set => _contractNum = value?.Trim();
    }

    /// <summary>
    /// Дата договора
    /// </summary>
    public string? ContractDate
    {
      get => _contractDate;
      set => _contractDate = value?.Trim();
    }

    /// <summary>
    /// Код организации хранящей запасы ТМЦ
    /// </summary>
    public string EnterpriseCode
    {
      get => _enterpriseCode;
      set => _enterpriseCode = value.Trim();
    }

    /// <summary>
    /// Страна изготовитель
    /// </summary>
    public string? CountryCode
    {
      get => _countryCode;
      set => _countryCode = value?.Trim();
    }

  }
}
