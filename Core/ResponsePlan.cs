namespace Core
{
    public class ResponsePlan
    {
        public PageType PageType;
        public string FileData = "";
        public Dictionary<string, DataModelBase> DataModelDict = [];
        public ResponsePlan(PageType pageType)
        {
            PageType = pageType;
        }

        public void SetFileData(string fileData)
        {
            FileData = fileData;
        }

        public void AddData(string dataName, DataModelBase dataValue)
        {
            DataModelDict[dataName] = dataValue;
        }
    }

    public enum PageType
    {
        INDEX
    }
}