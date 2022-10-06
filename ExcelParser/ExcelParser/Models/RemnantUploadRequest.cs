using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable enable

namespace ExcelParser.Models
{
  /// <summary>
  /// Запрос на загрузку остатков ТМЦ на складе
  /// </summary>
  public class RemnantUploadRequest
  {
    /// <summary>
    /// Идентификтаор сессии
    /// </summary>
    [Required]
    public string SessionId { get; set; } = null!;

    /// <summary>
    /// Идентификатор пакета
    /// </summary>
    public string? PackageId { get; set; }

    /// <summary>
    /// Массив остатков
    /// </summary>
    [Required]
    [MinLength(1, ErrorMessage = "Массив описателей остатков не должен быть пустым")]
    public IEnumerable<Remnant> Remnants { get; set; } = Array.Empty<Remnant>();
  }
}
