using System.Data;
using Microsoft.Data.Sqlite;

namespace DataBaseService1
{
    public static class SqliteHelper
    {
        public static void EnsureConnectionIsOpen(SqliteConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

    }
}