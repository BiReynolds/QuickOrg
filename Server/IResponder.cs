namespace Server
{
    public interface IResponder
    {
        public ResponseInfo Respond(RequestInfo requestInfo);
    }
}