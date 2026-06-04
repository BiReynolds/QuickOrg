using Core;

namespace Placeholders
{
    public class ResponsePlannerPlaceholder : IResponsePlanner
    {
        public ResponsePlan GetResponsePlan(RequestInfo requestInfo)
        {
            ResponsePlan result = new(PageType.INDEX);
            result.FileData = requestInfo.RequestedFile;
            return result;
        }
    }
}