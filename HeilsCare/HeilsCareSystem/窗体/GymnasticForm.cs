using System;
using System.Linq;
using XYS.Remp.Screening.Public;
using XYS.Remp.Screening;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;     //与这个 using System.Windows.Media.Imaging;有点重
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Threading;

namespace HeilsCareSystem
{
    public partial class GymnasticForm : XYS.Remp.Screening.BaseForm
    {
        public readonly string Code;
        public VM_Question[] Question;

        /// <summary>
        /// Kinect 的相关变量
        /// </summary>
        //彩色空间变量
        private KinectSensor kinectSensor = null; //Kinect传感器
        private ColorFrameReader colorFrameReader = null; //Kinect彩色帧读取器
        private WriteableBitmap colorBitmap = null; //要显示的彩色图---SDK样例
        private Bitmap bmpShow; //PictureBox上要显示的图像

        //Body空间变量
        private const float InferredZPositionClamp = 0.1f;
        private CoordinateMapper coordinateMapper = null; //坐标映射器
        private BodyFrameReader bodyFrameReader = null;   //body帧读取器
        private Body[] bodies = null;   //代表了一个人骨架
        private int depthDisplayWidth;  //深度帧的宽度
        private int depthDisplayHeight; //深度帧的高度

        private bool isDebugMode = false;  // true-调试模式


        public GymnasticForm()
        {
            InitializeComponent();


            axWindowsMediaPlayerGym.enableContextMenu = false; //不显示播放位置的右键菜单
            axWindowsMediaPlayerGym.fullScreen = false;        //不全屏显示
            axWindowsMediaPlayerGym.uiMode = "none";           //没有下面的控制条
            this.WindowState = FormWindowState.Maximized;

            picUser.SizeMode = PictureBoxSizeMode.Zoom;

            InitUnity();
        }

        public GymnasticForm(string code, string title)
            : this()
        {
            Code = code;
            lblQuestionnaireTitle.Text = title;
        }

        #region 切换窗口
        /// <summary>
        /// 切换窗口
        /// </summary>
        /// <param name="form"></param>
        public void TurnToForm(GymnasticForm form)
        {
            form.TopMost = false;
            form.Show();
            Close();
        }

        #endregion

        #region 退出按钮事件
        /// <summary>
        /// 退出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);

            var quitComfirmFrm = new QuitComfirmFrm(GetParentForm(), this);
            quitComfirmFrm.ShowDialog();
        }

        #endregion

        #region 返回按钮事件
        /// <summary>
        /// 返回按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            var frmMain = GetParentForm();
            frmMain.TopMost = false;
            frmMain.Show();
            Close();
        }

        #endregion

        #region 下一页加载事件
        /// <summary>
        /// 下一页加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnNext_Click(object sender, EventArgs e)
        {
            SavaAnswer();
        }
        #endregion

        #region 上一页按钮事件
        /// <summary>
        /// 上一页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnBefore_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region 窗口加载事件
        /// <summary>
        /// 窗口加载事件(必须在子类重写)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void FormLoadEven(object sender, EventArgs e)
        {
            BeginInvoke(new Action(LoadAnswer));
        }

        #endregion

        #region 加载答案
        /// <summary>
        /// 加载答案
        /// </summary>
        public virtual void LoadAnswer()
        {
            if (Question == null || !Question.Any()) return;
            var answer = Question.Select(p => ClientInfo.GetAnswerByCode(Code, p.Code)).ToArray();
            for (int i = 0, length = answer.Length; i < length; i++)
            {
                Question[i].Parse(answer[i]);
            }
        }
        #endregion

        #region 保存答案

        /// <summary>
        /// 保存答案
        /// </summary>
        public virtual void SavaAnswer()
        {
            if (Question == null || !Question.Any()) return;
            foreach (var item in Question
                                .Select(p => p.ToResultDetail())
                                .Where(p => p != null))
            {
                ClientInfo.AddQuestionToQuestionnaire(item, Code);
            }
        }

        #endregion

        #region 获取父窗口
        /// <summary>
        /// 获取父窗口
        /// </summary>
        /// <returns></returns>
        public virtual XYS.Remp.Screening.BaseForm GetParentForm()
        {
            return new XYS.Remp.Screening.BaseForm();
        }
        #endregion

        private void btnOpenKinect_Click(object sender, EventArgs e)
        {
            //string str = "3.54" + "," + "6.89" + "," + "7.45" + "," + "9.3";
            //axUnityWebPlayer1.SendMessage("MCube", "ReceiveInfo", str);

            InitKinect(); //初始化Kinect相关信息
        }





        private void InitUnity()
        {
            axUnityWebPlayerMain.OnExternalCall += axUnityWebPlayerMain_OnExternalCall; //接收unity消息的响应函数
        }

        /// <summary>
        /// 接收unity消息的响应函数
        /// <summary>
        private void axUnityWebPlayerMain_OnExternalCall(object sender, AxUnityWebPlayerAXLib._DUnityWebPlayerAXEvents_OnExternalCallEvent e)
        {
            MessageBox.Show("接收到Unity的消息了" + e.value);
            int lth = e.value.Length;
            string subMsg = null;

            if (lth == 9)
            {
                subMsg = e.value.Substring(2, 4);
            }
            if (lth == 18)
            {
                subMsg = e.value.Substring(2, 13);
            }
            HandleUnityMsg(subMsg);
        }

        /// <summary>
        /// 处理Unity发过来的消息
        /// <summary>
        // 总体原则：凡是收到back返回消息，都需要停止视频播放，停止Kinect显示；其余的事件单独处理
        private void HandleUnityMsg(string unityMsg)
        {
            string videoPath = Application.StartupPath + "\\VideoStandard\\" + unityMsg + ".mp4"; //注：对视频的文件名有要求
            axWindowsMediaPlayerGym.URL = videoPath;

            switch (unityMsg)     //C#支持 string 类型的 switch-case 
            {
                case "Back":     //返回
                    axWindowsMediaPlayerGym.URL = null;
                    axWindowsMediaPlayerGym.Ctlcontrols.stop(); //停止播放
                    break;
                case "Ch2_Sec1_Pas1":  //第二章第一节
                    axWindowsMediaPlayerGym.Ctlcontrols.play();
                    break;
                case "Ch2_Sec1_Pas2":
                    axWindowsMediaPlayerGym.Ctlcontrols.play();
                    break;
                case "Ch2_Sec1_Pas3":
                    axWindowsMediaPlayerGym.Ctlcontrols.play();
                    break;
                case "Ch2_Sec1_Pas4":
                    axWindowsMediaPlayerGym.Ctlcontrols.play();
                    break;
                case "Ch2_Sec1_Pas5":
                    axWindowsMediaPlayerGym.Ctlcontrols.play();
                    break;
                case "Ch2_Sec1_Pas6":
                    axWindowsMediaPlayerGym.Ctlcontrols.play();
                    break;
                case "Ch2_Sec1_Pas7":
                    axWindowsMediaPlayerGym.Ctlcontrols.play();
                    break;

                case "Ch2_Sec2_Pas1": //第二章第二节
                    break;
                case "Ch2_Sec2_Pas2":
                    break;
                case "Ch2_Sec2_Pas3":
                    break;
                case "Ch2_Sec2_Pas4":
                    break;
                case "Ch2_Sec2_Pas5":
                    break;
                case "Ch2_Sec2_Pas6":
                    break;
                case "Ch2_Sec2_Pas7":
                    break;

                case "Ch2_Sec3_Pas1": //第二章第三节
                    break;
                case "Ch2_Sec3_Pas2":
                    break;
                case "Ch2_Sec3_Pas3":
                    break;
                case "Ch2_Sec3_Pas4":
                    break;
                case "Ch2_Sec3_Pas5":
                    break;
                case "Ch2_Sec3_Pas6":
                    break;
                case "Ch2_Sec3_Pas7":
                    break;
                case "Ch2_Sec3_Pas8":
                    break;
                case "Ch2_Sec3_Pas9":
                    break;
            }

        }

        /// <summary>
        /// 视频循环播放控制
        /// </summary>
        private void axWMPSample_StatusChange(object sender, EventArgs e)
        {
            if ((int)axWindowsMediaPlayerGym.playState == 1)
            {
                System.Threading.Thread.Sleep(2000);
                axWindowsMediaPlayerGym.Ctlcontrols.play();
            }
        }


        /// <summary>
        ///Kinect传感器的相关初始化
        /// <summary>
        private void InitKinect()
        {
            kinectSensor = KinectSensor.GetDefault(); //获取默认的Kinect

            //彩色帧相关初始化
            colorFrameReader = kinectSensor.ColorFrameSource.OpenReader();
            colorFrameReader.FrameArrived += Reader_ColorFrameArrived; //彩色帧事件
            FrameDescription colorFrameDescription = kinectSensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Bgra);
            colorBitmap = new WriteableBitmap(colorFrameDescription.Width, colorFrameDescription.Height, 96.0, 96.0, PixelFormats.Bgr32, null);
            bmpShow = new Bitmap(colorFrameDescription.Width, colorFrameDescription.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            //Body帧相关初始化
            coordinateMapper = kinectSensor.CoordinateMapper;
            FrameDescription depthFrameDescription = kinectSensor.DepthFrameSource.FrameDescription;
            depthDisplayWidth = depthFrameDescription.Width;
            depthDisplayHeight = depthFrameDescription.Height;
            bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader(); //打开Body帧读取器
            bodyFrameReader.FrameArrived += bodyFrameReader_FrameArrived; //body帧事件

            kinectSensor.Open(); //打开Kinect传感器
        }

        /// <summary>
        /// 彩色图像事件处理
        /// <summary>
        private void Reader_ColorFrameArrived(object sender, ColorFrameArrivedEventArgs e)
        {
            using (ColorFrame colorFrame = e.FrameReference.AcquireFrame())
            {
                if (colorFrame == null)
                    return;

                FrameDescription colorFrameDescription = colorFrame.FrameDescription;
                using (KinectBuffer colorBuffer = colorFrame.LockRawImageBuffer())
                {
                    //colorBitmap.Lock(); //保留后台缓冲区用于更新

                    //if ((colorFrameDescription.Width == colorBitmap.PixelWidth) && (colorFrameDescription.Height == colorBitmap.PixelHeight))
                    //{
                    //    colorFrame.CopyConvertedFrameDataToIntPtr(colorBitmap.BackBuffer, (uint)(colorFrameDescription.Width * colorFrameDescription.Height * 4), ColorImageFormat.Bgra);
                    //    colorBitmap.AddDirtyRect(new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight));

                    //}

                    //colorBitmap.Unlock(); //释放后台缓冲区，以使之可用于显示

                    //BitmapData bmpShowData = bmpShow.LockBits(new Rectangle(0, 0, colorFrameDescription.Width, colorFrameDescription.Height), 
                    //    ImageLockMode.WriteOnly,System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    //colorFrame.CopyConvertedFrameDataToIntPtr(bmpShowData.Scan0, (uint)(colorFrameDescription.Width * colorFrameDescription.Height * 4),
                    //    ColorImageFormat.Bgra);
                    //bmpShow.UnlockBits(bmpShowData);
                    //bmpShow.RotateFlip(RotateFlipType.Rotate180FlipY); //相对于Y轴上对PictureBox物体做左右翻转

                    ////Graphics gDraw = Graphics.FromImage(bmpShow);    //画图测试
                    ////System.Drawing.Pen penSamp = new System.Drawing.Pen(System.Drawing.Color.Blue,(float)10.0);
                    ////gDraw.DrawLine(penSamp, 0, 0, 500, 500);

                    //picUser.Image = bmpShow;

                }

            }
        }


        private int fileIndex = 0;
        private long liPreviousTime = 0;
        private long liRelativeTime = 0;

        /// <summary>
        /// Body帧事件处理
        /// <summary>
        private void bodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;

            string strAllData = null;     //要发送的数据

            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame == null)
                    return;

                if (bodies == null)
                {
                    bodies = new Body[bodyFrame.BodyCount];
                }
                bodyFrame.GetAndRefreshBodyData(bodies);
                dataReceived = true;

                liPreviousTime = liRelativeTime;
                liRelativeTime = bodyFrame.RelativeTime.Ticks;
                strAllData = strAllData + liPreviousTime.ToString() + ","; // long
                strAllData = strAllData + liRelativeTime.ToString() + ","; // long
            }

            if (!dataReceived)
            {
                return;
            }

            foreach (Body body in bodies)
            {
                if (body.IsTracked)
                {
                    //fileIndex++;
                    //string fileName = fileIndex.ToString() + ".txt";
                    //FileStream fs = new FileStream(fileName, FileMode.Create);

                    short bIsTracked = 1;
                    strAllData = strAllData + bIsTracked.ToString() + ",";                       // short
                    strAllData = strAllData + body.TrackingId.ToString() + ",";                  // long
                    strAllData = strAllData + ((int)body.HandLeftState).ToString() + ",";        // enum
                    strAllData = strAllData + ((int)body.HandLeftConfidence).ToString() + ",";   // enum
                    strAllData = strAllData + ((int)body.HandRightState).ToString() + ",";       // enum
                    strAllData = strAllData + ((int)body.HandRightConfidence).ToString() + ",";  // enum

                    strAllData = strAllData + "Mid" + ",";                                       //分隔上下数据

                    IReadOnlyDictionary<JointType, Joint> joints = body.Joints;
                    Dictionary<JointType, System.Windows.Point> jointPoints = new Dictionary<JointType, System.Windows.Point>();
                    foreach (JointType jointType in joints.Keys)
                    {
                        CameraSpacePoint position = joints[jointType].Position; //照相机空间中的点
                        if (position.Z < 0)
                        {
                            position.Z = InferredZPositionClamp;
                        }

                        strAllData = strAllData + ((int)joints[jointType].TrackingState).ToString() + ",";   // enum
                        strAllData = strAllData + joints[jointType].Position.X.ToString() + ",";             // float
                        strAllData = strAllData + joints[jointType].Position.Y.ToString() + ",";
                        strAllData = strAllData + joints[jointType].Position.Z.ToString() + ",";

                        DepthSpacePoint depthSpacePoint = coordinateMapper.MapCameraPointToDepthSpace(position); //转换到深度空间-二维点
                        jointPoints[jointType] = new System.Windows.Point(depthSpacePoint.X, depthSpacePoint.Y);

                    }

                    strAllData = strAllData + "End";                                                      //数据结束标志

                    //调试用---检测骨骼点是否正确检测到

                    //Graphics gDraw = Graphics.FromImage(bmpShow);
                    //gDraw.Clear(System.Drawing.Color.White);
                    //System.Drawing.Pen penDraw = new System.Drawing.Pen(System.Drawing.Color.Blue, 10.0f);
                    //gDraw.DrawLine(penDraw, (int)jointPoints[JointType.Head].X, (int)jointPoints[JointType.Head].Y,
                    //    (int)jointPoints[JointType.SpineShoulder].X, (int)jointPoints[JointType.SpineShoulder].Y);
                    //picUser.Image = bmpShow;

                    //gDraw.DrawLine(penDraw, (int)jointPoints[JointType.HipLeft].X, (int)jointPoints[JointType.HipLeft].Y,
                    //    (int)jointPoints[JointType.HipRight].X, (int)jointPoints[JointType.HipRight].Y);

                    //StreamWriter sw = new StreamWriter(fs);
                    //sw.Write(strAllData);
                    //sw.Close();
                    //fs.Close();

                    try
                    {
                        axUnityWebPlayerMain.SendMessage("MKinectManager", "ReceiveWinformInfo", strAllData);  //给unity发消息
                        Thread.Sleep(10);
                    }
                    catch (Exception ex)
                    {

                    }


                    break;  //检测一个人就行
                }

            }
        }

        private void GymnasticForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //释放Kinect传感器的相关资源
            if (colorFrameReader != null)
            {
                colorFrameReader.Dispose();
                colorFrameReader = null;
            }
            if (kinectSensor != null)
            {
                kinectSensor.Close();
                kinectSensor = null;
            }

            if (bodyFrameReader != null)
            {
                bodyFrameReader.Dispose();
                bodyFrameReader = null;
            }
        }

    }
}
