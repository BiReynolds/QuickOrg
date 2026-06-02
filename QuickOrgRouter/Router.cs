using Server;

namespace QuickOrgRouter
{
    public class Router : IRouter
    {
        private Dictionary<string, RequestInfo> RouteMap = new()
        {
            {"/test", new RequestInfo("test.html", RequestType.PAGE)}
        };
        public Router() { }

        public RequestInfo GetRequestInfoFromUrl(string url)
        {
            string requestExtension = RequestHelper.GetExtension(url);
            switch(requestExtension)
            {
                case "js":
                    return new RequestInfo(url, RequestType.SCRIPT);
                case "css":
                    return new RequestInfo(url, RequestType.STYLE);
                default:
                    try
                    {
                        return RouteMap[url];
                    }
                    catch
                    {
                        return new RequestInfo(url, RequestType.BAD_REQUEST);
                    }
            }
        }

        public void AddRoute(string url, RequestInfo RequestInfo)
        {
            RouteMap[url] = RequestInfo;
        }
    }
}