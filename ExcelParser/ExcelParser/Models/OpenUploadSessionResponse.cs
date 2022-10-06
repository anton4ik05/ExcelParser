namespace ExcelParser.Models
{
  /// <summary>
  /// Ответ на запрос открытия сессии
  /// </summary>
  public class OpenUploadSessionResponse
  {
    /// <summary>
    /// Идентификатор сессии
    /// </summary>
    public string SessionId { get; set; } = null!;
  }
}
