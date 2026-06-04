namespace Core
{
    public class RequestInfo
    {
        public string RequestedPage;
        public string RequestedFile;
        public Dictionary<string, DataRequestBase> RequestedData;
        public RequestInfo(string requestedPage, string requestedFile, Dictionary<string, DataRequestBase> requestedData)
        {
            RequestedPage = requestedPage;
            RequestedFile = requestedFile;
            RequestedData = requestedData;
        }
    }
}