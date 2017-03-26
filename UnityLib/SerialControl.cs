
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

public class SerialControl : MonoBehaviour 
{
    public float setSpeedX = 0.0f;
    public float setSpeedY = 0.0f;
    public float setSpeedRot = 0.0f;
    public float MoveSpeed = 600.0f;
    private SerialPort sPort = new SerialPort();
    public string serialName = "COM6";
    const int receiveSize = 21;
    private int[] receiveData = new int[receiveSize];
    public float[] UltrasonicRanging = new float[8];//8个超声波
    public float[] InfraredRanging = new float[6];//6个激光测距
    public bool[] collisionSwitch = new bool[4];//4个碰撞开关
    public float[] motorSpeed = new float[2];//左右底盘电机
    public int timeStamp = 0;
    public int robotPower = 0;

    const int receiveDataLength = 45;
    private Thread serialThread;
	// Use this for initialization
	void Start () {
        sPort.PortName = serialName;
        sPort.BaudRate = 9600;
        sPort.ReadTimeout = 200;
        sPort.WriteTimeout = 100;
        if (!sPort.IsOpen)
        {
            try
            {
                sPort.Open();
            }
            catch(Exception ex)
            {
                Debug.Log(ex);
            }
            if(sPort.IsOpen)
                Debug.Log("Open SerialPorts Successfully!");
        }

        serialThread = new Thread(serialData);
        serialThread.Start(); 
	}

	// Update is called once per frame
	void Update () 
    {
        if (!serialThread.IsAlive)
        {
            serialThread.Start();
            Debug.Log("The serialThread start failed! Start again automatically!");
        }
            
        else
        {
            if (sPort.IsOpen)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
                    this.setSpeedY = MoveSpeed;
                    this.setSpeedRot = 0.0f;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed);
                    this.setSpeedY = -MoveSpeed;
                    this.setSpeedRot = 0.0f;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
                    this.setSpeedY = 0.0f;
                    this.setSpeedRot = -MoveSpeed;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
                    this.setSpeedY = 0.0f;
                    this.setSpeedRot = MoveSpeed;
                }
                else
                {
                    this.setSpeedY = 0.0f;
                    this.setSpeedRot = 0.0f;
                }
            }
            else
            {
                this.setSpeedY = 0.0f;
                this.setSpeedRot = 0.0f;
                Debug.Log("The SerialPort is open failed! Please check out!");
            }
        }
 
	}

    void OnApplicationQuit()
    {
        //要首先杀死线程，之后关闭串口，否则会出现串口异常读写操作
        if (serialThread.IsAlive)
            serialThread.Abort();
        if(sPort.IsOpen)
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
                SendSpeed();
                string rebuffData = null;
                try
                {
                    rebuffData = sPort.ReadLine();
                    //Debug.Log(rebuffData);
                    if (rebuffData != null)
                    {
                        string pattern = @"\d{1,10}";
                        MatchCollection match = Regex.Matches(rebuffData, pattern);

                        for (int iCount = 0; iCount < receiveSize; iCount++)
                        {
                            receiveData[iCount] = Convert.ToInt32(match[iCount].ToString());
                            if(iCount < 2)
                            {
                                motorSpeed[iCount] = System.Convert.ToSingle(receiveData[iCount]);
                                //Debug.Log("Motor" + iCount + ":" + motorSpeed[iCount]);
                            }
                            else if (iCount >= 2 && iCount < 6)
                            {
                                collisionSwitch[iCount - 2] = System.Convert.ToBoolean(receiveData[iCount]);
                                //Debug.Log("Switch" + (iCount - 2) + ":" + collisionSwitch[iCount - 2]);
                            }
                            else if (iCount >= 6 && iCount < 12)
                            {
                                InfraredRanging[iCount - 6] = System.Convert.ToSingle(receiveData[iCount]);
                                //Debug.Log("Infrared" + (iCount - 6) + ":" + InfraredRanging[iCount - 6]);
                            }
                            else if (iCount >= 12 && iCount < 20)
                            {
                                UltrasonicRanging[iCount - 12] = System.Convert.ToSingle(receiveData[iCount]);
                                //Debug.Log("Ultrasonic" + (iCount - 12) + ":" + UltrasonicRanging[iCount - 12]);
                            }
                            else if(iCount == 20)
                            {
                                robotPower = System.Convert.ToInt32(receiveData[iCount]);
                                //Debug.Log("robotPower" + ":" + robotPower);
                            }
                            else
                            {
                                timeStamp = System.Convert.ToInt32(receiveData[iCount]);
                                //Debug.Log("timeStamp" + ":" + timeStamp);
                            }
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
            Thread.Sleep(10);
        }

    }
}