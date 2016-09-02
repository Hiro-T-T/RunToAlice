using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;

public class Client
{
    private TcpClient _clinet = null;
    private string ip = "localhost";
    private NetworkStream _stream;


    public Client()
    {

    }

    public void ConnecttoServer(int port)
    {
        _clinet = new TcpClient(ip, port);
        _stream = _clinet.GetStream();
    }

    public void WritetoServer()
    {

    }

    public void ReadfromServer()
    {

    }
    
}
