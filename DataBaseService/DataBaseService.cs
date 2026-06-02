namespace DataBaseService1
{
    public class DataBaseService
    {
        private bool IsInitialized = false;
        private string DBPath = "";
        public DataBaseService() { }
        public void Init(string dbPath)
        {
            DBPath = dbPath;
            IsInitialized = true;
        }
    }
}