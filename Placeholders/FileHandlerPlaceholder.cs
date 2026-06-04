using Core;

namespace Placeholders
{
    public class FileHandlerPlaceholder : IFileHandler
    {
        public FileHandlerPlaceholder()
        {

        }

        public string GetDataFromFile(string requestedFile)
        {
            return requestedFile;
        }
    }
}