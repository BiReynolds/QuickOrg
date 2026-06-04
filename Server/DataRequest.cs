namespace Server
{
    public class DataRequest<DataType>
    {
        public Dictionary<string, object> ParameterDict = new();
        public void SetParameter(string parName, string parValue)
        {
            ParameterDict[parName] = parValue;
        }
    }

    public enum DataRequestType
    {
        PROJECT
    }
}