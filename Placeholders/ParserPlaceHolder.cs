using Core;

namespace Placeholders
{
    public class ParserPlaceholder : IParser
    {
        public ParserPlaceholder() { }
        public RequestInfo Parse(string rawUrl)
        {
            return new RequestInfo(rawUrl, rawUrl, []);
        }
    }
}