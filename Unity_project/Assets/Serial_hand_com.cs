using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class Serial_hand_com : MonoBehaviour
{
    public string portName = "COM10"; // Arduino���ӵĴ��ںţ�����ʵ������޸�
    public int baudRate = 115200; // ��Arduino���������õĲ�������ͬ

    private SerialPort serialPort;
    private string receivedData;


    public CommandSender commandSender;
    public RotateObjectsLocal rotateObjectsLocal;

    void Start()
    {
        // ��ʼ������
        serialPort = new SerialPort(portName, baudRate);
        try
        {
            serialPort.Open(); // �򿪴���
            serialPort.ReadTimeout = 50; // ���ö�ȡ��ʱ
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error opening serial port: " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                // �Ӵ��ڶ�ȡ����
                receivedData = serialPort.ReadLine();
                Debug.Log("Received data: " + receivedData);

                // ������յ�������...
                // int data = int.Parse(receivedData);

                // ������յ�������...
                string[] dataSplit = receivedData.Split(',');
                string idString = dataSplit[0].Split(':')[1];
                string rString = dataSplit[1].Split(':')[1];
                int id = int.Parse(idString);
                float r = float.Parse(rString);
                Debug.Log("ID: " + id + ", R: " + r);


                if (id == 0 )
                {
                    if ( r > 1808495.50)
                    {
                        //changeColor.ChangeObjectColorBlue();
                        rotateObjectsLocal.RotateObjectOnXAxis(id,90f);
                        commandSender.SendCommand_detail(id+1, 1900);                        
                        Debug.Log(id);
                    }
                    else
                    {
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 0f);
                        commandSender.SendCommand_detail(id + 1, 1000);
                        Debug.Log(id);
                    }
                   
                }

                if (id == 1)
                {
                    if (r > 1808495.50)
                    {
                        //changeColor.ChangeObjectColorBlue();
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 90f);
                        commandSender.SendCommand_detail(id + 1, 1000);
                        Debug.Log(id);
                    }
                    else
                    {
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 0f);
                        commandSender.SendCommand_detail(id + 1, 1900);
                        Debug.Log(id);
                    }

                }

                if (id == 2)
                {
                    if (r > 1808495.50)
                    {
                        //changeColor.ChangeObjectColorBlue();
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 90f);
                        commandSender.SendCommand_detail(id + 1, 1000);
                        Debug.Log(id);
                    }
                    else
                    {
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 0f);
                        commandSender.SendCommand_detail(id + 1, 1900);
                        Debug.Log(id);
                    }

                }

                if (id == 3)
                {
                    if (r > 1808495.50)
                    {
                        //changeColor.ChangeObjectColorBlue();
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 90f);
                        commandSender.SendCommand_detail(id + 1, 1000);
                        Debug.Log(id);
                    }
                    else
                    {
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 0f);
                        commandSender.SendCommand_detail(id + 1, 1900);
                        Debug.Log(id);
                    }

                }
                if (id == 4)
                {
                    if (r > 1808495.50)
                    {
                        //changeColor.ChangeObjectColorBlue();
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 90f);
                        commandSender.SendCommand_detail(id + 1, 1000);
                        Debug.Log(id);
                    }
                    else
                    {
                        rotateObjectsLocal.RotateObjectOnXAxis(id, 0f);
                        commandSender.SendCommand_detail(id + 1, 1900);
                        Debug.Log(id);
                    }

                }


                else
                {
                    Debug.Log("0");
                }
            }

            catch (System.TimeoutException)
            {
                // ��ʱ��ζ����ָ��ʱ����û�н��յ��µ�����
            }

            // ʾ������Arduino��������
            if (Input.GetKeyDown(KeyCode.Space))
            {
                serialPort.WriteLine("Hello Arduino");
            }
        }
    }

    void OnDisable()
    {
        // �رմ���
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
