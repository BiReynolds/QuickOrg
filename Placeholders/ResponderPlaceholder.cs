using Core;

namespace Placeholders
{
    public class ResponderPlaceholder : ResponderBase
    {
        public ResponderPlaceholder() : base(new ResponsePlannerPlaceholder(), new FileHandlerPlaceholder(), new DatabaseManagerPlaceholder())
        {   

        }
    }
}