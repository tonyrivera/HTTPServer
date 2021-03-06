﻿using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServer
{
    class Server
    {

        static void Main(string[] args)
        {
            // Config
            const string Uri = "http://localhost:";
            const int Port = 1337;
            const string Html = "<!DOCTYPE html><html><body>Success!</body></html>";
            byte[] data = Encoding.UTF8.GetBytes(Html);

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(Uri + Port.ToString() + "/");

            listener.Start();
            Console.WriteLine("Server started on " + Uri + Port.ToString());

            // HTTP Server Loop
            while(true)
            {

                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                RequestLogger(request);

                response.OutputStream.Write(data);
                response.Close();
            }
        }

        static void RequestLogger(HttpListenerRequest request)
        {
            string method = request.HttpMethod;
            string url = request.Url.ToString();
            string client = request.RemoteEndPoint.ToString();
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            Console.WriteLine($"{date} - {method} - {url} - {client}");
        }

    }
}