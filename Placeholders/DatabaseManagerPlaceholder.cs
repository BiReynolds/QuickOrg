using Core;

namespace Placeholders
{
    public class DatabaseManagerPlaceholder : IDatabaseManager
    {
        public DataModelBase GetDataFromDatabase(DataRequestBase request)
        {
            DataModelPlaceholder model = new();
            model.DataDict["placeholderKey"] = "placeholderValue";
            return model;
        }
    }
}