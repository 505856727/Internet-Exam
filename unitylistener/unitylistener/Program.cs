using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Socket listenfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAdr = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEp = new IPEndPoint(ipAdr, 1234);
            listenfd.Bind(ipEp);
            listenfd.Listen(0);
            Console.WriteLine("服务器启动");
            while (true)
            {
                Socket connfd = listenfd.Accept();
                Console.WriteLine("服务器已经连接");
                byte[] readBuff = new byte[1024];
                int count = connfd.Receive(readBuff);
                string str = Encoding.UTF8.GetString(readBuff, 0, count);
                Console.WriteLine("服务器接收" + str);
                byte[] bytes = Encoding.Default.GetBytes("serv echo" + str);
                connfd.Send(bytes);
            }
        }
    }
}
