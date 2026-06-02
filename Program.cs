using Server;

public static class Program
{
    public static void Main()
    {
        Services.DBService.Init("./Data/QuickOrgDEV.db", "./Data/Scripts");
        MainServer server = new("./Pages", "./Pages/Scripts", "./Pages/Styles");
        server.StartServer();
    }
}