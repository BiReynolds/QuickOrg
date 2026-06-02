namespace Server
{
    public class DataRequest<DataType>
    {
        DataType DefaultValue;
        Dictionary<string, string> ParameterDict = new();
        public void SetParameter(string parName, string parValue)
        {
            ParameterDict[parName] = parValue;
        }

        public string GetParameterValue(string parName)
        {
            if (ParameterDict.ContainsKey(parName))
            {
                return ParameterDict[parName];
            }
            else
            {
                return "";
            }
        }
    }
}