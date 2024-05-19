using UnityEngine;
using System.Collections;
//引入庫
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Client : MonoBehaviour
{
    float editString; //編輯框文字

    //以下默認都是私有的成員
    Socket socket; //目標socket
    EndPoint serverEnd; //服務端
    IPEndPoint ipEnd; //服務端端口
    string recvStr; //接收的字符串
    string sendStr; //發送的字符串
    byte[] recvData = new byte[1024]; //接收的數據，必須爲字節
    byte[] sendData = new byte[1024]; //發送的數據，必須爲字節
    int recvLen; //接收的數據長度
    Thread connectThread; //連接線程
    // public string number;
    //MIDI
    public string noteNum;
    // public Transform cube;
    // public string ipInput;
    // public KeyButton keyButton;
    
    //初始化
    void InitSocket()
    {
        //定義連接的服務器ip和端口，可以是本機ip，局域網，互聯網
        //for PC test
        // ipEnd = new IPEndPoint(IPAddress.Parse("192.168.1.25"), 8001); // ip adress
        //for VR/real test
        ipEnd = new IPEndPoint(IPAddress.Parse(KeyButton.ipInput), 8001); // ip adress
        // Debug.Log("IP:"+KeyButton.ipInput);
        //定義套接字類型,在主線程中定義
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //定義服務端
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        serverEnd = (EndPoint)sender;
        print("waiting for sending UDP dgram");

        //建立初始連接，這句非常重要，第一次連接初始化了serverEnd後面才能收到消息
        SocketSend("hello");

        //開啓一個線程連接，必須的，否則主線程卡死
        connectThread = new Thread(new ThreadStart(SocketReceive));
        connectThread.Start();
    }

    void SocketSend(string sendStr)
    {
        //清空發送緩存
        sendData = new byte[1024];
        //數據類型轉換
        sendData = Encoding.ASCII.GetBytes(sendStr);
        //發送給指定服務端
        socket.SendTo(sendData, sendData.Length, SocketFlags.None, ipEnd);
    }

    //服務器接收
    void SocketReceive()
    {
        //進入接收循環
        while (true)
        {
            //對data清零
            recvData = new byte[1024];
            //獲取客戶端，獲取服務端端數據，用引用給服務端賦值，實際上服務端已經定義好並不需要賦值
            recvLen = socket.ReceiveFrom(recvData, ref serverEnd);
            print("message from: " + serverEnd.ToString()); //打印服務端信息
            //輸出接收到的數據
            recvStr = Encoding.ASCII.GetString(recvData, 0, recvLen);
            print("This is recvStr"+recvStr);
        }
    }


    //連接關閉
    void SocketQuit()
    {
        //關閉線程
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        //最後關閉socket
        if (socket != null)
            socket.Close();
    }

    // Use this for initialization
    void Start()
    {
        InitSocket(); //在這裏初始化
    }


    // Update is called once per frame
    void Update()
    {

        // if(recvStr != null && cube != null)
        // {
        //     number = recvStr; //-----get from server
        // }
         if(recvStr != null)
        {
            noteNum = recvStr; //-----get from server
        }
    }

    void OnApplicationQuit()
    {
        SocketQuit();
    }

    // public static Vector3 Parse(string str)
    // {
    //     str = str.Replace("(", " ").Replace(")", " ");
    //     string[] s = str.Split(',');
    //     return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    // }
}
