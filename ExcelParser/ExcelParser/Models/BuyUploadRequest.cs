using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable enable

namespace ExcelParser.Models
{
  /// <summary>
  /// Объект запроса на загрузку закупок товаров
  /// </summary>
  public class BuyUploadRequest
  {
    /// <summary>
    /// Идентификатор сессии
    /// </summary>
    [Required]
    public string SessionId { get; set; } = null!;
    
    /// <summary>
    /// Идентификатор пакета. Может использоваться в целях отладки
    /// </summary>
    public string? PackageId { get; set; }
    
    /// <summary>
    /// Массив описателей закупок товаров
    /// </summary>
    [Required]
    [MinLength(1, ErrorMessage = "Массив описателей закупок не может быть пустым")]
    public BuyItem[] Items { get; set; } = Array.Empty<BuyItem>();
  }
}
