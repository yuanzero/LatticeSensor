using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class SerialPortCommunication : MonoBehaviour
{
    public string portName = "COM3"; // Arduino���ӵĴ��ںţ�����ʵ������޸�
    public int baudRate = 9600; // ��Arduino���������õĲ�������ͬ

    private SerialPort serialPort;
    private string receivedData;

    public ChangeColor changeColor;

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
