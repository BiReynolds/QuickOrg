using Server;

namespace QuickOrgPageService
{
    public class PageService : IResponder
    {
        readonly string PagesFolder;
        readonly string ScriptsFolder;
        readonly string StylesFolder;
        public Dictionary<RequestType, ResponseType> RequestToResponseDict = new()
        {
            {RequestType.PAGE, ResponseType.PAGE},
            {RequestType.SCRIPT, ResponseType.SCRIPT},
            {RequestType.STYLE, ResponseType.STYLE},
            {RequestType.BAD_REQUEST, ResponseType.ERROR}
        };
        public PageService(string pagesFolder, string scriptsFolder, string stylesFolder)
        {
            PagesFolder = pagesFolder;
            ScriptsFolder = scriptsFolder;
            StylesFolder = stylesFolder;
        }

        public ResponseInfo Respond(RequestInfo requestInfo)
        {
            ResponseType responseType = RequestToResponseDict[requestInfo.RequestType];
            return new ResponseInfo(responseType, GetRequestedData(requestInfo));
        }

        public string GetRequestedData(RequestInfo requestInfo)
        {
            switch (requestInfo.RequestType)
            {
                case RequestType.SCRIPT:
                    return GetScriptString(requestInfo);
                case RequestType.STYLE:
                    return GetStyleString(requestInfo);
                case RequestType.BAD_REQUEST:
                    return "bad request :/";
                default:
                    return GetPageString(requestInfo);
            }
        }

        string GetPageString(RequestInfo requestInfo)
        {
            string result;
            using (StreamReader reader = new(Path.Join(PagesFolder, requestInfo.RequestString)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        string GetScriptString(RequestInfo requestInfo)
        {
            string result;
            using (StreamReader reader = new(Path.Join(ScriptsFolder, requestInfo.RequestString)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        string GetStyleString(RequestInfo requestInfo)
        {
            string result;
            using (StreamReader reader = new(Path.Join(StylesFolder, requestInfo.RequestString)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        
    }
}