using Viten.QueryBuilder;
using Viten.QueryBuilder.Renderer;

namespace ExcelParser.Utils
{
    /// <summary>
    /// Класс для работы с БД
    /// </summary>
    public static class DbUtils
    {
        /// <summary>
        /// Метод получения sql-кода из запроса на выборку
        /// </summary>
        /// <param name="select">Запрос на выборку</param>
        /// <returns>Возвращает sql-код в виде строки</returns>
        public static string GetSql(Select select)
        {
            PostgreSqlRenderer render = new();

            return render.RenderSelect(select);
        }
    }
}