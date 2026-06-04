using System.Net;
using System.Text;
using Core;
using Placeholders;

namespace Tests
{
    public static class ServerTests
    {
        public static async Task EmptyServerTest()
        {
            WebServerBase emptyServer = new(new ParserPlaceholder(), new ResponderPlaceholder(), new ResponseWriterPlaceholder());
            HttpListener listener = new();
            string url = "http://localhost:8000/";
            listener.Prefixes.Add(url);
            Console.WriteLine($"Server listening at {url}");
            listener.Start();
            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                string responseString = emptyServer.GetResponse(request.RawUrl ?? "");
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                HttpListenerResponse response = context.Response;
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = buffer.LongLength;
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.Close();
            }
        }
    }
}