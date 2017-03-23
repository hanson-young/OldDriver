using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Public
{
    public partial class CustomNumKeyboard : Form
    {
        //唯一实例
        private static CustomNumKeyboard _customNumKeyboard;

        //获取实例
        public static CustomNumKeyboard GetInstance(object sender)
        {
            if (_customNumKeyboard == null)
            {
                _customNumKeyboard = new CustomNumKeyboard(sender);
            }
            return _customNumKeyboard;
        }

        private CustomNumKeyboard(object sender)
        {
            InitializeComponent();
            TopMost = false;
            BackColor = Color.FromArgb(228,243,251);
            //FormBorderStyle = FormBorderStyle.None;

            #region 按钮样式
            btn1.BackColor = Color.FromArgb(228, 243, 251);
            btn1.FlatAppearance.BorderColor = Color.FromArgb(142,190, 237);
            btn2.BackColor = Color.FromArgb(228, 243, 251);
            btn2.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btn3.BackColor = Color.FromArgb(228, 243, 251);
            btn3.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btn4.BackColor = Color.FromArgb(228, 243, 251);
            btn4.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btn5.BackColor = Color.FromArgb(228, 243, 251);
            btn5.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btn6.BackColor = Color.FromArgb(228, 243, 251);
            btn6.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btn7.BackColor = Color.FromArgb(228, 243, 251);
            btn7.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btn8.BackColor = Color.FromArgb(228, 243, 251);
            btn8.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btn9.BackColor = Color.FromArgb(228, 243, 251);
            btn9.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btn0.BackColor = Color.FromArgb(228, 243, 251);
            btn0.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btnDot.BackColor = Color.FromArgb(228, 243, 251);
            btnDot.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btnCancel.BackColor = Color.FromArgb(228, 243, 251);
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            btnExit.BackColor = Color.FromArgb(228, 243, 251);
            btnExit.FlatAppearance.BorderColor = Color.FromArgb(142, 190, 237);
            #endregion

            #region 点击事件
            btn1.Click += CusClick;
            btn2.Click += CusClick;
            btn3.Click += CusClick;
            btn4.Click += CusClick;
            btn5.Click += CusClick;
            btn6.Click += CusClick;
            btn7.Click += CusClick;
            btn8.Click += CusClick;
            btn9.Click += CusClick;
            btn0.Click += CusClick;
            btnDot.Click += CusClick;
            btnCancel.Click += CusClick; 
            #endregion

            //初始位置
            int x = MousePosition.X + Width > Screen.PrimaryScreen.WorkingArea.Width ? MousePosition.X - Width/2 : MousePosition.X;
            int y = MousePosition.Y + (sender as TextBox).Height;
            StartPosition=FormStartPosition.Manual;
            Location=new Point(x,y);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams ret = base.CreateParams;
                //(int)WindowStyles.WS_THICKFRAME 厚边框可改变大小
                ret.Style = (int)WindowStyles.WS_THICKFRAME | (int)WindowStyles.WS_CHILD;
                //ret.Style = (int)WindowStyles.WS_CHILD;
                ret.ExStyle |= (int)WindowStyles.WS_EX_NOACTIVATE | (int)WindowStyles.WS_EX_TOOLWINDOW;
                return ret;
            }
        }

        private void CusClick(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if ((sender as Button).Name.Equals("btnCancel"))
                {
                    SendKeys.Send("{BACKSPACE}");
                }
                else
                {
                    SendKeys.Send((sender as Button).Text);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _customNumKeyboard = null;
            ////Close();
            Dispose();
            //Hide();
        }

        public void CloseKeyboard()
        {
            _customNumKeyboard = null;
            ////Close();
            Dispose();
            //Hide();
        }
    }

    public enum WindowStyles : uint
    {
        WS_OVERLAPPED = 0x00000000,
        WS_POPUP = 0x80000000,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x08000000,
        WS_CLIPSIBLINGS = 0x04000000,
        WS_CLIPCHILDREN = 0x02000000,
        WS_MAXIMIZE = 0x01000000,
        WS_BORDER = 0x00800000,
        WS_DLGFRAME = 0x00400000,
        WS_VSCROLL = 0x00200000,
        WS_HSCROLL = 0x00100000,
        WS_SYSMENU = 0x00080000,
        WS_THICKFRAME = 0x00040000,
        WS_GROUP = 0x00020000,
        WS_TABSTOP = 0x00010000,

        WS_MINIMIZEBOX = 0x00020000,
        WS_MAXIMIZEBOX = 0x00010000,

        WS_CAPTION = WS_BORDER | WS_DLGFRAME,
        WS_TILED = WS_OVERLAPPED,
        WS_ICONIC = WS_MINIMIZE,
        WS_SIZEBOX = WS_THICKFRAME,
        WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
        WS_CHILDWINDOW = WS_CHILD,

        //Extended Window Styles

        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_ACCEPTFILES = 0x00000010,
        WS_EX_TRANSPARENT = 0x00000020,

        //#if(WINVER >= 0x0400)

        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_WINDOWEDGE = 0x00000100,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,

        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,

        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,

        WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
        WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),

        //#endif /* WINVER >= 0x0400 */

        //#if(WIN32WINNT >= 0x0500)

        WS_EX_LAYERED = 0x00080000,

        //#endif /* WIN32WINNT >= 0x0500 */

        //#if(WINVER >= 0x0500)

        WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
        WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring

        //#endif /* WINVER >= 0x0500 */

        //#if(WIN32WINNT >= 0x0500)

        WS_EX_COMPOSITED = 0x02000000,
        WS_EX_NOACTIVATE = 0x08000000

        //#endif /* WIN32WINNT >= 0x0500 */
    }
}
