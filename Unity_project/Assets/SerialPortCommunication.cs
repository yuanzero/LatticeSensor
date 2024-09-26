using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class SerialPortCommunication : MonoBehaviour
{
    public string portName = "COM3"; // Arduino连接的串口号，根据实际情况修改
    public int baudRate = 9600; // 与Arduino代码中设置的波特率相同

    private SerialPort serialPort;
    private string receivedData;

    public ChangeColor changeColor;

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
                int data = int.Parse(receivedData);
                if (data > 100000 && data < 300000)
                {
                    changeColor.ChangeObjectColorBlue();
                    Debug.Log("Blue");
                }

                if (data > 300000 && data < 1808495.50)
                {
                    changeColor.ChangeObjectColorRed();
                    Debug.Log("Red");
                }

                if (data > 1808495.50)
                {
                    changeColor.ChangeObjectColorGreen();
                    Debug.Log("Green");
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
