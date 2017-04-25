
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

public class Acc : MonoBehaviour
{
    public float setSpeedX = 0.0f;
    public float setSpeedY = 0.0f;
    public float setSpeedRot = 0.0f;
    public float MoveSpeed = 600.0f;
    private SerialPort sPort = new SerialPort();
    public string serialName = "COM6";
    const int receiveSize = 4;
    public float[] receiveData = new float[receiveSize];
    public int timeStamp = 0;
    public int robotPower = 0;
    Vector3 Rot = new Vector3(0,0,0);
    const int receiveDataLength = 45;
    private Thread serialThread;
    Quaternion qua = new Quaternion(0,0,0,0);
    // Use this for initialization
    void Start()
    {
        sPort.PortName = serialName;
        sPort.BaudRate = 115200;
        sPort.ReadTimeout = 200;
        sPort.WriteTimeout = 100;
        if (!sPort.IsOpen)
        {
            try
            {
                sPort.Open();
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
            if (sPort.IsOpen)
                Debug.Log("Open SerialPorts Successfully!");
        }

        serialThread = new Thread(serialData);
        serialThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!serialThread.IsAlive)
        //{
        //    serialThread.Start();
        //    Debug.Log("The serialThread start failed! Start again automatically!");
        //}
        if (sPort.IsOpen)
        {
            
            //Rot.x = receiveData[1];
            //Rot.y = receiveData[0];
            //Rot.z = receiveData[2] - 180;
            //Rot.z = 90;
            //qua = Quaternion.Euler(Rot);
            //this.transform.rotation = qua;
            //this.transform.rotation = Quaternion.Euler(Rot);
            qua.Set(receiveData[1], receiveData[2], receiveData[3],receiveData[0]);
            this.transform.rotation = qua;
            //this.transform.rotation = Quaternion.(receiveData[0], receiveData[1], receiveData[2], receiveData[3]);

        }
        else
        {
            this.setSpeedY = 0.0f;
            this.setSpeedRot = 0.0f;
            Debug.Log("The SerialPort is open failed! Please check out!");
        }


    }

    void OnApplicationQuit()
    {
        //要首先杀死线程，之后关闭串口，否则会出现串口异常读写操作
        if (serialThread.IsAlive)
            serialThread.Abort();
        if (sPort.IsOpen)
            sPort.Close();

        Debug.Log("Close Successfully!");
    }

    private void SendSpeed()
    {
        byte[] hexhead = { 0x0D, 0x0A };
        byte[] hextail = { 0x0A, 0x0D };
        byte[] speedxBuff = BitConverter.GetBytes(this.setSpeedX);
        byte[] speedyBuff = BitConverter.GetBytes(this.setSpeedY);
        byte[] speedrotBuff = BitConverter.GetBytes(this.setSpeedRot);

        sPort.Write(hexhead, 0, 2);
        sPort.Write(speedxBuff, 0, 4);
        sPort.Write(speedyBuff, 0, 4);
        sPort.Write(speedrotBuff, 0, 4);
        sPort.Write(hextail, 0, 2);
    }

    private void serialData()
    {
        while (true)
        {
            if (sPort.IsOpen)
            {
                //SendSpeed();
                string rebuffData = null;
                try
                {
                    rebuffData = sPort.ReadLine();
                    //Debug.Log(rebuffData);
                    if (rebuffData != null)
                    {
                        string pattern = @"(\-|\+)?\d{0,5}\.\d{0,4}";
                        MatchCollection match = Regex.Matches(rebuffData, pattern);
                        //print(rebuffData);
                        if (match.Count == receiveSize)
                            for (int iCount = 0; iCount < receiveSize; iCount++)
                            {
                                receiveData[iCount] = Convert.ToSingle(match[iCount].ToString());
                            }
                    }

                }
                catch (Exception ex)
                {
                    Debug.Log("ReadLine Error!Please check out serial port!");
                    Debug.Log(ex);
                }
            }
            else
            {
                sPort.Open();
                Debug.Log("The serial port is not connected! Please check out serial port!");
            }
            Thread.Sleep(5);
        }

    }
}