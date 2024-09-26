using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class CommandSender : MonoBehaviour
{
    public string serverIP = "127.0.0.1"; // 服务器IP地址
    public int serverPort = 8888; // 服务器端口号

    private TcpClient client;
    private NetworkStream stream;

    public int angle;
    public int ID;
    public bool switch_on;

    int previousAngle;

    int previousID;



    private void Start()
    {
        try
        {
            client = new TcpClient(serverIP, serverPort);
            stream = client.GetStream();
            
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e.Message);
        }
    }

    void FixedUpdate()
    {
        if (switch_on == true)
        {
            if (angle != previousAngle || ID != previousID)
            {

                if (client == null || !client.Connected) { Start(); }

                SendCommandAction();
                OnDestroy();
                previousAngle = angle;
                previousID = ID;
            }
        }
    }

    public void SendCommand(string command)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(command);
            stream.Write(data, 0, data.Length);
        }
        catch (Exception e)
        {
            Debug.Log("Error sending command: " + e.Message);
        }
    }

    private void OnDestroy()
    {
        stream.Close();
        client.Close();
    }

    public void SendCommandAction()
    {
        SendCommand(ID.ToString() + ":" + angle.ToString() +"; ");
    }

    public void SendCommand_detail(int ID, int angle)
    {
        if (client == null || !client.Connected) { Start(); }
        SendCommand(ID.ToString() + ":" + angle.ToString() + "; ");
        OnDestroy();
    }
}
