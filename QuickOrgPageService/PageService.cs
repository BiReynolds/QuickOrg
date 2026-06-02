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
            {RequestType.STYLE, ResponseType.STYLE}
        };
        public PageService(string pagesFolder, string scriptsFolder, string stylesFolder)
        {
            PagesFolder = pagesFolder;
            ScriptsFolder = scriptsFolder;
            StylesFolder = stylesFolder;
        }

        public string GetRequestedData(RequestInfo requestInfo)
        {
            switch (requestInfo.RequestType)
            {
                case RequestType.SCRIPT:
                    return GetScriptString(requestInfo);
                case RequestType.STYLE:
                    return GetStyleString(requestInfo);
                default:
                    return GetPageString(requestInfo);
            }
        }

        public ResponseInfo Respond(RequestInfo requestInfo)
        {
            ResponseType responseType = RequestToResponseDict[requestInfo.RequestType];
            return new ResponseInfo(responseType, GetRequestedData(requestInfo));
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