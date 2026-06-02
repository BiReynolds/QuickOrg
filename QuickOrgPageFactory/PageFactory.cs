using Server;

namespace QuickOrgPageFactory
{
    public class PageFactory : IPageFactory
    {
        public PageFactory()
        {

        }

        public string Write(ResponseInfo responseInfo)
        {
            return responseInfo.HtmlString;
        }
    }
}