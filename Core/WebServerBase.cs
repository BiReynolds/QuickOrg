namespace Core
{
    public class WebServerBase
    {
        IParser Parser;
        IResponder Responder;
        IResponseWriter ResponseWriter;

        public WebServerBase(IParser parser, IResponder responder, IResponseWriter responseWriter)
        {
            Parser = parser;
            Responder = responder;
            ResponseWriter = responseWriter;
        }

        public string GetResponse(string rawRequest)
        {
            RequestInfo requestInfo = Parser.Parse(rawRequest);
            ResponsePlan responsePlan = Responder.HandleRequest(requestInfo);
            return ResponseWriter.WriteResponse(responsePlan);
        }
    }

    public interface IParser
    {
        public RequestInfo Parse(string rawUrl);
    }

    public interface IResponder
    {
        public ResponsePlan HandleRequest(RequestInfo requestInfo);
    }

    public interface IResponseWriter
    {
        public string WriteResponse(ResponsePlan responsePlan);
    }
}