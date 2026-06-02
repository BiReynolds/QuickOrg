using Microsoft.Data.Sqlite;

namespace DataBaseService1
{
    public static class DBVersionManager
    {
        public static void EnsureDBVersion(SqliteConnection connection, string dbScriptPath)
        {
            SqliteHelper.EnsureConnectionIsOpen(connection);
            EnsureDBExists(connection, dbScriptPath);
            connection.Close();
        }
        private static void EnsureDBExists(SqliteConnection connection, string dbScriptPath)
        {
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
                CreateDB(connection, dbScriptPath);
            }
        }

        private static void CreateDB(SqliteConnection connection, string dbScriptPath)
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = File.ReadAllText(Path.Join(dbScriptPath, @"DBInit.sql"));
            command.ExecuteNonQuery();
        }
    }
}