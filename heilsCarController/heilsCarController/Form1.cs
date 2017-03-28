using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace heilsCarController
{
    public partial class Form1 : Form
    {
        //k=true;
        
        public SerialPort sPort = new SerialPort();

        public float speedx;
        public float speedy;
        public float speedz;

        public string receiveData = null;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sPort.PortName = "com6";
            sPort.BaudRate = 9600;
            sPort.Open();
            this.speedx = 0.0f;
            this.speedy = 0.0f;
            this.speedz = 0.0f;
            SendStringData(sPort);
            ReceiveData();
            sendBox.Text = "(" + ((float)this.speedx).ToString() + "," + ((float)this.speedy).ToString() + "," + ((float)this.speedz).ToString() + ")";

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            

        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            //sPort.Write(sendBox.Text);
            //string sendMessage = null;
            byte[] hexhead = { 0x0D, 0x0A };
            byte[] hextail = { 0x0A, 0x0D };
//           string message = ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString();
            byte[] speedxBuff = BitConverter.GetBytes(this.speedx);
            byte[] speedyBuff = BitConverter.GetBytes(this.speedy);
            byte[] speedzBuff = BitConverter.GetBytes(this.speedz);

            //byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(sendMessage);
            // byte[] sendData = Encoding.Unicode.GetBytes(sendMessage);
            sPort.Write(hexhead, 0, 2);
            sPort.Write(speedxBuff, 0, 4);
            sPort.Write(speedyBuff, 0, 4);
            sPort.Write(speedzBuff, 0, 4);
            sPort.Write(hextail, 0, 2);

        }

        private void receiveBtn_Click(object sender, EventArgs e)
        {
            receiveBox.Text = this.receiveData;
        }

        private void SendStringData(SerialPort serialPort)
        {
            serialPort.Write(sendBox.Text);
        }  

        private void SynReceiveData()
        {
            int[] a = { 0, 0, 0, 0, 0 };
            while(true)
            {
                //sPort.Write(sendBox.Text);
                //string sendMessage = null;
                byte[] hexhead = { 0x0D, 0x0A };
                byte[] hextail = { 0x0A, 0x0D };
                //           string message = ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString();
                byte[] speedxBuff = BitConverter.GetBytes(this.speedx);
                byte[] speedyBuff = BitConverter.GetBytes(this.speedy);
                byte[] speedzBuff = BitConverter.GetBytes(this.speedz);

                //byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(sendMessage);
                // byte[] sendData = Encoding.Unicode.GetBytes(sendMessage);
                sPort.Write(hexhead, 0, 2);
                sPort.Write(speedxBuff, 0, 4);
                sPort.Write(speedyBuff, 0, 4);
                sPort.Write(speedzBuff, 0, 4);
                sPort.Write(hextail, 0, 2);

                if (sPort.ReadLine() == null)
                {
                    return;
                }
                else
                    receiveData = sPort.ReadLine();
                string pattern = @"\d{0,5}\.\d{0,2}";
                //MatchCollection match = Regex.Matches(receiveData, pattern);

                //for (int iCount = 0; iCount < 5;iCount++ )
                //{
                //    a[iCount] = Convert.ToInt32(match[iCount].ToString());
                //}
                Thread.Sleep(20);

            }

            //receiveBox.Text = receiveData;
        }
        private void ReceiveData()
        {
            Thread threadReceive = new Thread(new ThreadStart(SynReceiveData));
            threadReceive.Start();
            //while (threadReceive.IsAlive);
            //Thread.Sleep(1);
            //threadReceive.Abort();


        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        int count = 0;
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            count++;
            if (e.KeyCode.ToString() == Keys.A.ToString() || e.KeyCode.ToString() == "a")
            {
                label1.Text = "Left" + count;
                this.speedy = 0.0f;
                this.speedz = -600.0f;
            }
            else if (e.KeyCode.ToString() == Keys.W.ToString() || e.KeyCode.ToString() == "w")
            {
                label2.Text = "Up" + count;
                this.speedz = 0.0f;
                this.speedy = 600.0f;
            }
            else if (e.KeyCode.ToString() == Keys.D.ToString() || e.KeyCode.ToString() == "d")
            {
                label3.Text = "Right" + count;
                this.speedy = 0.0f;
                this.speedz = 600.0f;

            }
            else if (e.KeyCode.ToString() == Keys.S.ToString() || e.KeyCode.ToString() == "s")
            {
                label4.Text = "Down" + count;
                this.speedz = 0.0f;
                this.speedy = -600.0f;
            }
            else
            {
                this.speedz = 0.0f;
                this.speedy = 0.0f;
            }
            byte[] hexhead = { 0x0D, 0x0A };
            byte[] hextail = { 0x0A, 0x0D };
            //           string message = ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString();
            byte[] speedxBuff = BitConverter.GetBytes(this.speedx);
            byte[] speedyBuff = BitConverter.GetBytes(this.speedy);
            byte[] speedzBuff = BitConverter.GetBytes(this.speedz);

            //byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(sendMessage);
            // byte[] sendData = Encoding.Unicode.GetBytes(sendMessage);
            sPort.Write(hexhead, 0, 2);
            sPort.Write(speedxBuff, 0, 4);
            sPort.Write(speedyBuff, 0, 4);
            sPort.Write(speedzBuff, 0, 4);
            sPort.Write(hextail, 0, 2);
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == Keys.A.ToString() || e.KeyCode.ToString() == "a")
            {
                label1.Text = "stop";
                this.speedz = 0.0f;
                this.speedy = 0.0f;
            }
            else if (e.KeyCode.ToString() == Keys.W.ToString() || e.KeyCode.ToString() == "w")
            {
                label2.Text = "stop";
                this.speedz = 0.0f;
                this.speedy = 0.0f;
            }
            else if (e.KeyCode.ToString() == Keys.D.ToString() || e.KeyCode.ToString() == "d")
            {
                label3.Text = "stop";
                this.speedz = 0.0f;
                this.speedy = 0.0f;
            }
            else if (e.KeyCode.ToString() == Keys.S.ToString() || e.KeyCode.ToString() == "s")
            {
                label4.Text = "stop";
                this.speedz = 0.0f;
                this.speedy = 0.0f;
            }
            else
            {
                this.speedz = 0.0f;
                this.speedy = 0.0f;
            }
            byte[] hexhead = { 0x0D, 0x0A };
            byte[] hextail = { 0x0A, 0x0D };
            //           string message = ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString();
            byte[] speedxBuff = BitConverter.GetBytes(this.speedx);
            byte[] speedyBuff = BitConverter.GetBytes(this.speedy);
            byte[] speedzBuff = BitConverter.GetBytes(this.speedz);

            //byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(sendMessage);
            // byte[] sendData = Encoding.Unicode.GetBytes(sendMessage);
            sPort.Write(hexhead, 0, 2);
            sPort.Write(speedxBuff, 0, 4);
            sPort.Write(speedyBuff, 0, 4);
            sPort.Write(speedzBuff, 0, 4);
            sPort.Write(hextail, 0, 2);
        }


    }
}
