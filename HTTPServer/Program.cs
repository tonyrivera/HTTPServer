using System;
using System.Net;
using System.Text;

namespace HTTPServer
{
    class Server
    {
        static void Main(string[] args)
        {
            // Config
            const string URI = "http://localhost:";
            const int PORT = 1337;
            const string html = "<b>Test</b>";
            byte[] data = Encoding.UTF8.GetBytes(html);

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(URI + PORT.ToString() + "/");

            listener.Start();
            Console.WriteLine("Server started on " + URI + PORT.ToString());

            // HTTP Server Loop
            while(true){

                HttpListenerContext context = listener.GetContext();
                // HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                response.OutputStream.Write(data);
                response.Close();
            }
        }
    }
}