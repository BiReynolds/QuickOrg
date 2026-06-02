namespace Server
{
    public class ResponseInfo
    {
        public ResponseType ResponseType;
        public string HtmlString;
        public Dictionary<string, object> DataDict = new();
        public ResponseInfo(ResponseType responseType, string htmlString)
        {
            ResponseType = responseType;
            HtmlString = htmlString;
        }
    }

    public enum ResponseType
    {
        PAGE,
        SCRIPT,
        STYLE,
        ERROR
    }
}