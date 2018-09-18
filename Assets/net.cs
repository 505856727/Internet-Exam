using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class net : MonoBehaviour {

    Socket socket;
    public InputField hostInput;
    public InputField portInput;
    public Text recvText;
    public Text clientText;
    const int BUFFER_SIZE = 1024;
    byte[] readBuff = new byte[BUFFER_SIZE];

    public void Connetion()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string host = hostInput.text;
        int port = int.Parse(portInput.text);
        socket.Connect(host, port);
        clientText.text = "客户端地址" + socket.LocalEndPoint.ToString();
        string str = "Hello Unity!";
        byte[] bytes = Encoding.Default.GetBytes(str);
        socket.Send(bytes);
        int count = socket.Receive(readBuff);
        str = Encoding.UTF8.GetString(readBuff, 0, count);
        recvText.text = str;
        socket.Close();
    }
}
