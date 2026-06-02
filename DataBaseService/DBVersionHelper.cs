using System.Data;
using Microsoft.Data.Sqlite;

namespace DataBaseService1
{
    public static class DBVersionHelper
    {
        public static void EnsureDBExists(SqliteConnection connection)
        {
            EnsureConnectionIsOpen(connection);
            try
            {
                using var command = connection.CreateCommand();
                command.CommandText = """
                SELECT TOP 1 * from Projects;
                SELECT TOP 1 * from Tasks;
                """;
                command.ExecuteReader();
            }
            catch
            {
                CreateDB(connection);
            }
        }

        public static void CreateDB(SqliteConnection connection)
        {
        }

        private static void EnsureConnectionIsOpen(SqliteConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
    }
}