using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Text;

public class Client : MonoBehaviour
{
    // メッセージを管理するリスト
    //private List<string> messages = new List<string>();
    // Chat用のテキスト
    private string currentMessage = string.Empty;
    // Server
    NetworkStream stream = null;
    bool isStopReading = false;
    byte[] readbuf;
    public Action<string> MessageReceived = null;
    public Action<string> AtButtonReceived = null;

    private ManualResetEvent _connect = new ManualResetEvent(false);
    TcpClient tcp;

    public Client()
    {
    }

    //~Client()
    //{
    //    Close();
    //}

    public bool ConnectionStart()
    {
        int count = 0;
        while (count < 5)
        {
            count++;
            stream = GetNetworkStream();
            if (stream != null) return true;
        }
        return false;
    }

    public IEnumerator StartReadLoop()
    {
        readbuf = new byte[1024];

        while (true)
        {
            ReadMessage();
            yield return null;
        }
    }

    public IEnumerator StartReading()
    {
        readbuf = new byte[1024];
        while (true)
        {
            if (!isStopReading && stream != null && stream.DataAvailable) { ReadMessage(); }
            yield return null;
        }
    }

    public void SendPlayerInfo(PlayerInfo pi)
    {
        currentMessage = JsonUtility.ToJson(pi);

        StartCoroutine(SendMessage(currentMessage));
    }

    public IEnumerator SendMessage(string message)
    {
        //Debug.Log("START SendMessage:" + message);

        if (stream == null)
        {
            stream = GetNetworkStream();
        }
        //サーバーにデータを送信する
        Encoding enc = Encoding.UTF8;
        byte[] sendBytes = enc.GetBytes(message + "\n");
        //データを送信する
        stream.Write(sendBytes, 0, sendBytes.Length);

        //if (message == "close")
        //{
        //    stream.Close();
        //    if (tcp != null)
        //        tcp.Close();
        //}
        yield break;
    }

    private void ReadMessage()
    {

        //stream = GetNetworkStream();
        //Debug.Log("gotStream");
        // 非同期で待ち受けする
        stream.BeginRead(readbuf, 0, readbuf.Length, new AsyncCallback(ReadCallback), null);
        isStopReading = true;

    }

    public void ReadCallback(IAsyncResult ar)
    {
        Encoding enc = Encoding.UTF8;
        if (stream == null) return;
        int bytes = stream.EndRead(ar);
        string message = enc.GetString(readbuf, 0, bytes);
        print("read1 : " + message);
        //message = message.Replace("\r", "").Replace("\n", "");
        isStopReading = false;

        //print("read2 : " + message);
        if (message.Contains("pressatb"))
            OnAtButtonReceived(message.Substring(9, message.Length));
        else
            OnMessageReceived(message);
    }

    private NetworkStream GetNetworkStream()
    {
        if (stream != null && stream.CanRead)
        {
            return stream;
        }

        //string ipOrHost = "localhost";
        string ipOrHost = "172.20.10.5";

        int port = 5022;

        try
        {
            //TcpClientを作成し、サーバーと接続する
            //TcpClient tcp = new TcpClient(ipOrHost, port);


            _connect.Reset();

            tcp = new TcpClient();
            tcp.NoDelay = true;
            tcp.BeginConnect(ipOrHost, port, new AsyncCallback(ConnectCallback), tcp);

            if (!_connect.WaitOne(1000))
            {
                tcp.Close();
                throw new SocketException();
            }

            Debug.Log("success conn server ; " + tcp.Connected);

            //NetworkStreamを取得する
            return tcp.GetStream();
        }
        catch
        {
            return null;
        }

    }

    private void ConnectCallback(IAsyncResult result)
    {
        _connect.Set();
    }

    public void Close()
    {
        if (stream != null)
        {
            print("Client Close");
            StartCoroutine(SendMessage("close"));
        }
    }

    public void RequestClientNum()
    {
        if (stream != null)
        {
            StartCoroutine(SendMessage("clientnum"));
        }
    }

    private void OnApplicationQuit()
    {
        Close();
    }

    private void OnMessageReceived(string message)
    {
        Action<string> tmp = MessageReceived;
        if (tmp != null)
        {
            tmp(message);
        }
    }

    private void OnAtButtonReceived(string str)
    {
        Action<string> tmp = AtButtonReceived;
        if (tmp != null)
        {
            tmp(str);
        }
    }

    //private Socket GetSocket()
    //{
    //    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
    //    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 10021);
    //    Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    //    listener.Bind(localEndPoint);
    //    listener.Listen(10);
    //    return listener;
    //}

}

