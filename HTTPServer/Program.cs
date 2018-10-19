using System;
using System.Net;
using System.Text;

namespace HTTPServer
{
    class Server
    {
        static void Main(string[] args)
        {
        
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:1337/");

            listener.Start();
            Console.WriteLine("Server started: http://localhost:1337/");

            const string html = "<b>Test</b>";
            byte[] data = Encoding.UTF8.GetBytes(html);

            // HTTP Server Loop
            while(true){

                HttpListenerContext context = listener.GetContext();
                HttpListenerResponse response = context.Response;
                response.OutputStream.Write(data);
                response.Close();
            }
        }
    }
}
