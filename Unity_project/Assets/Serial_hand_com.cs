using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class Serial_hand_com : MonoBehaviour
{
    public string portName = "COM10"; // Arduino连接的串口号，根据实际情况修改
    public int baudRate = 115200; // 与Arduino代码中设置的波特率相同

    private SerialPort serialPort;
    private string receivedData;


    public CommandSender commandSender;
    public RotateObjectsLocal rotateObjectsLocal;

    void Start()
    {
        // 初始化串口
        serialPort = new SerialPort(portName, baudRate);
        try
        {
            serialPort.Open(); // 打开串口
            serialPort.ReadTimeout = 50; // 设置读取超时
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
                // 从串口读取数据
                receivedData = serialPort.ReadLine();
                Debug.Log("Received data: " + receivedData);

                // 处理接收到的数据...
                // int data = int.Parse(receivedData);

                // 处理接收到的数据...
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
                // 超时意味着在指定时间内没有接收到新的数据
            }

            // 示例：向Arduino发送数据
            if (Input.GetKeyDown(KeyCode.Space))
            {
                serialPort.WriteLine("Hello Arduino");
            }
        }
    }

    void OnDisable()
    {
        // 关闭串口
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
