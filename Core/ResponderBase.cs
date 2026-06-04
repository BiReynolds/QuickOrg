namespace Core
{
    public abstract class ResponderBase : IResponder
    {
        IResponsePlanner ResponsePlanner;
        IFileHandler FileHandler;
        IDatabaseManager DBManager;
        public ResponderBase(IResponsePlanner responsePlanner, IFileHandler fileHandler, IDatabaseManager dbManager)
        {
            ResponsePlanner = responsePlanner;
            FileHandler = fileHandler;
            DBManager = dbManager;
        }

        public ResponsePlan HandleRequest(RequestInfo requestInfo)
        {
            ResponsePlan plan = ResponsePlanner.GetResponsePlan(requestInfo);
            if (plan.FileData.Length > 0)
            {
                string fileData = FileHandler.GetDataFromFile(requestInfo.RequestedFile);
                plan.SetFileData(fileData);
            }
            foreach (string name in requestInfo.RequestedData.Keys)
            {
                DataRequestBase request = requestInfo.RequestedData[name];
                plan.AddData(name, DBManager.GetDataFromDatabase(request));
            }
            return plan;
        }
    }

    public interface IResponsePlanner
    {
        public ResponsePlan GetResponsePlan(RequestInfo requestInfo);
    }

    public interface IFileHandler
    {
        public string GetDataFromFile(string requestedFile);
    }

    public interface IDatabaseManager
    {
        public DataModelBase GetDataFromDatabase(DataRequestBase request);
    }
}