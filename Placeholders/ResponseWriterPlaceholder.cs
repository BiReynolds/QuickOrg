using Core;

namespace Placeholders
{
    public class ResponseWriterPlaceholder : IResponseWriter
    {
        public string WriteResponse(ResponsePlan responsePlan)
        {
            return responsePlan.FileData;
        }
    }
}