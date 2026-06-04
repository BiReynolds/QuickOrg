using Microsoft.Data.Sqlite;
using Models;
using Server;

namespace DataBaseService1
{
    public class DataBaseService
    {
        private bool IsInitialized = false;
        private string? DBPath;
        private string? DBScriptPath;
        SqliteConnection? DBConnection;
        public DataBaseService() { }
        public void Init(string dbPath, string dbScriptPath)
        {
            DBPath = dbPath;
            DBScriptPath = dbScriptPath;
            DBConnection = new($"Data Source={dbPath}");
            DBVersionManager.EnsureDBVersion(DBConnection, DBScriptPath);
            IsInitialized = true;
        }
    }
}