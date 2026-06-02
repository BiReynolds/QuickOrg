using Microsoft.Data.Sqlite;

namespace DataBaseService1
{
    public class DataBaseService
    {
        private bool IsInitialized = false;
        SqliteConnection? DBConnection;
        public DataBaseService() { }
        public void Init(string dbPath)
        {
            DBConnection = new("Data Source=dbPath");
            IsInitialized = true;
        }

        public void EnsureDBVersion()
        {
        }
    }
}