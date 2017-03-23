using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.HistoryData;
using XYS.Remp.Screening.Public;
using XYS.Remp.Screening.Services;
using DevComponents.DotNetBar.Metro;

namespace XYS.Remp.Screening
{
    public partial class XYSMainfrm : Form//MetroForm
    {
        //private ScreeningServiceClient screeningServiceClient = new ScreeningServiceClient();
        private ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        private int _activityId=0;
        private string _txtActivName = string.Empty;
        private string _activityName = string.Empty;

        private string _activityAdress = string.Empty;
        private DateTime? _activityStartDate=null;
        private DateTime? _activityEndDate=null;

        private int _cottageOrgId = -1;
        private string _txtCottageName = string.Empty;

        private int _doctorId=0;
        private string _doctorName = string.Empty;
        private string _txtDrAccount = string.Empty;

        //分页相关
        //总页数
        private int _pageCount = 0;
        //当前页码
        private int _pageIndex = 1;
        //每页条数
        private int _pageSize = 5;
        //查询的条件-名称
        private string _searchName = string.Empty;

        public XYSMainfrm()
        {
            InitializeComponent();
        }

        //保存设置按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            //访客模式，则将是否访客配置项置为true
            if (rbVisitor.Checked)
            {
                Properties.Settings.Default.SetIsCustomer = true;
                Properties.Settings.Default.Save();
            }

            //选择操作人员登录模式
            //保存全部设置
            if (rbOperator.Checked)
            {
                Properties.Settings.Default.SetIsCustomer = false;
                Properties.Settings.Default.Save();

                //判断活动是否过期
                if (_activityId > 0)
                {
                    //M_CottageActivity mCottageActivity= screeningServiceClient.GetMCottageActivityById(_activityId);
                    Model.M_CottageActivity mCottageActivity = screenWebapiClient.GetMCottageActivityById(_activityId);
                    if (mCottageActivity == null)
                    {
                        //MessageBox.Show("该小屋活动已经过期，请重新选择。","提示",MessageBoxButtons.OK);
                        var msgBox = new CustomMessageBox("该小屋活动已经过期，请重新选择。");
                        msgBox.ShowDialog();
                        return;
                    }
                    if (mCottageActivity.StartFlag.Equals("0"))
                    {
                        //MessageBox.Show("此活动尚未开始，请选择目前已经开始，并且还未结束的活动。", "提示", MessageBoxButtons.OK);
                        var msgBox = new CustomMessageBox("此活动尚未开始，请选择目前已经开始，并且还未结束的活动。");
                        msgBox.ShowDialog();
                        return;
                    }
                }
                
                if (string.IsNullOrEmpty(txtDrAccount.Text))
                {
                    var msgBox = new CustomMessageBox("请您输入账号！");
                    msgBox.ShowDialog();
                    return;
                }

                //var result = screeningServiceClient.GetDoctorInfoByAccount(txtDrAccount.Text);
                var result=screenWebapiClient.GetDoctorInfoByAccount(txtDrAccount.Text);
                if (result != null)
                {
                    _doctorId = result.DrID;
                    _doctorName = result.DrName;
                    _txtDrAccount = result.DrAccount;
                }
                else
                {
                    var msgBox = new CustomMessageBox("账号不存在！");
                    msgBox.ShowDialog();
                    return;
                }
            }
            

            RadioButton rbLoginMode = rbOperator.Checked ? rbOperator : rbVisitor;

            //弹出确认框
            string questionnaireName = "";
            if (rdAD.Checked) questionnaireName = rdAD.Text;
            if (rdKangfu.Checked) questionnaireName = rdKangfu.Text;
            if (rdNaocz.Checked) questionnaireName = rdNaocz.Text;
            if (rdZaoai.Checked) questionnaireName = rdZaoai.Text;
            if (rdOther.Checked) questionnaireName = rdOther.Text;

            MainfrmConfirmSave mainfrmConfirmSave = new MainfrmConfirmSave(rbLoginMode, txtDrAccount.Text, _activityName, questionnaireName, _txtCottageName,_activityAdress,_activityStartDate,_activityEndDate);
            mainfrmConfirmSave.saveHandler = SaveSettings;
            mainfrmConfirmSave.TopMost = false;
            mainfrmConfirmSave.ShowDialog();
        }

        //保存问卷设置并跳转页面
        public void SaveSettings()
        {
            //保存医生账号及名称等
            Properties.Settings.Default.DoctorId = _doctorId;
            Properties.Settings.Default.DoctorName = _doctorName;
            Properties.Settings.Default.txtDrAccount = _txtDrAccount;
            //Properties.Settings.Default.Save();
            
            //保存活动Id及名称等
            Properties.Settings.Default.ActivityId = _activityId;
            Properties.Settings.Default.txtActivName = _txtActivName;
            Properties.Settings.Default.ActivityName = _activityName;
            Properties.Settings.Default.ActivityAdress = _activityAdress;

            if (_activityStartDate.HasValue)
                Properties.Settings.Default.ActivityStartDate = Convert.ToDateTime(_activityStartDate);
            if (_activityEndDate.HasValue)
                Properties.Settings.Default.ActivityEndDate = Convert.ToDateTime(_activityEndDate);
            //Properties.Settings.Default.Save();

            //保存小屋Id及名称
            Properties.Settings.Default.CottageOrgId = _cottageOrgId;
            Properties.Settings.Default.txtCottageName = _txtCottageName;
            Properties.Settings.Default.Save();

            //将所选择活动设为专项活动
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //screeningServiceClient.UpdateCottageActivityTypeTo1(
                //    Properties.Settings.Default.ActivityId,
                //    1,
                //    _doctorId);
                screenWebapiClient.UpdateCottageActivityTypeTo1(
                    Properties.Settings.Default.ActivityId,
                    1,
                    _doctorId);
            }


            //保存问卷设置并跳转页面
            if (rdAD.Checked) Properties.Settings.Default.ScreenSet = 1;
            if (rdNaocz.Checked) Properties.Settings.Default.ScreenSet = 2;
            if (rdZaoai.Checked) Properties.Settings.Default.ScreenSet = 3;
            if (rdKangfu.Checked) Properties.Settings.Default.ScreenSet = 4;
            //其他
            if (rdOther.Checked) Properties.Settings.Default.ScreenSet = 5;
            Properties.Settings.Default.Save();

            BaseForm selectForm = null;
            int iWhichQuestion = Properties.Settings.Default.ScreenSet;
            switch (iWhichQuestion)
            {
                case 1://老年痴呆筛查
                    selectForm = new AD.FirstFrm();
                    break;
                case 2: //脑卒中筛查
                    selectForm = new Naocuzhong.FirstFrm();
                    break;
                case 3://早癌筛查
                    selectForm = new Zaoai.ScreeningZaoaiSelect();
                    break;
                case 4://工伤康复筛查
                    selectForm = new Kangfu.ScreeningSelect();
                    break;
                case 5:
                    selectForm = new Other.ScreenOtherSelect();
                    break;
                default:
                    break;
            }

            LoginFormNew loginFormNew = new LoginFormNew(selectForm);
            //LoginForm loginFormNew = new LoginForm(selectForm);
            loginFormNew.Show();
            this.Hide();
        }

        private void Mainfrm_Load(object sender, EventArgs e)
        {
            #region 设置样式

            label1.ForeColor = Color.FromArgb(45, 110, 159);
            rbOperator.ForeColor = Color.FromArgb(45, 110, 159);
            rbVisitor.ForeColor = Color.FromArgb(45, 110, 159);
            btnSearchActiv.BackColor = Color.FromArgb(44, 158, 41);
            btnSearchActiv.ForeColor = Color.White;
            BtnGetHouse.BackColor = Color.FromArgb(44, 158, 41);
            BtnGetHouse.ForeColor = Color.White;
            btnFirst.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.BorderSize = 0;
            btnNext.FlatAppearance.BorderSize = 0;
            btnLast.FlatAppearance.BorderSize = 0;
            btnSkip.BackColor = Color.FromArgb(1, 102, 172);
            btnSkip.ForeColor = Color.White;
            panel2.BackColor = Color.FromArgb(41, 109, 158);
            btnSave.BackColor = Color.White;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(41, 109, 158);
            btnSave.ForeColor = Color.FromArgb(45, 110, 159);
            btnTest.BackColor = Color.White;
            btnTest.FlatAppearance.BorderColor = Color.FromArgb(41, 109, 158);
            btnTest.ForeColor = Color.FromArgb(45, 110, 159);
            label3.ForeColor = Color.FromArgb(45, 110, 159);

            txtDrAccount.WaterText = "请输入操作人员账号";
            txtActivName.WaterText = "请输入活动主题";
            txtCottageName.WaterText = "请输入小屋名称";

            #endregion

            int iWhich = Properties.Settings.Default.ScreenSet;

            switch (iWhich)
            {
                case 1:
                    rdAD.Checked = true;
                    break;
                case 2:
                    rdNaocz.Checked = true;
                    break;
                case 3:
                    rdZaoai.Checked = true;
                    break;
                case 4:
                    rdKangfu.Checked = true;
                    break;
                case 5:
                    rdOther.Checked = true;
                    break;
                default:
                    break;
            }

            //加载组织
            //LoadOrganizationTree();

            //加载活动列表
            //LoadActivity();

            //显示上次的选择
            if (!string.IsNullOrEmpty(Properties.Settings.Default.txtActivName))
            {
                txtActivName.Text = Properties.Settings.Default.txtActivName;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.txtCottageName))
            {
                txtCottageName.Text = Properties.Settings.Default.txtCottageName;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.txtDrAccount))
            {
                txtDrAccount.Text = Properties.Settings.Default.txtDrAccount;
            }
            //用上次的选择初始化字段
            _activityId = Properties.Settings.Default.ActivityId;
            _activityName = Properties.Settings.Default.ActivityName;
            _txtActivName = Properties.Settings.Default.txtActivName;

            _cottageOrgId = Properties.Settings.Default.CottageOrgId;
            _txtCottageName = Properties.Settings.Default.txtCottageName;

            _doctorId = Properties.Settings.Default.DoctorId;
            _doctorName = Properties.Settings.Default.DoctorName;
            _txtDrAccount = Properties.Settings.Default.txtDrAccount;

            _activityAdress = Properties.Settings.Default.ActivityAdress;
            _activityStartDate = Properties.Settings.Default.ActivityStartDate;
            _activityEndDate = Properties.Settings.Default.ActivityEndDate;

            if (Properties.Settings.Default.SetIsCustomer)
            {
                rbVisitor.Checked = true;
            }
            else
            {
                rbOperator.Checked = true;
            }
            
            //分页相关
            SetBtnStatus();

            #region 样式

            //btnSearchActiv.BackColor = Color.FromArgb(44, 158, 41);
            //btnSearchActiv.ForeColor = Color.White;
            //BtnGetHouse.BackColor = Color.FromArgb(44, 158, 41);
            //BtnGetHouse.ForeColor = Color.White;
            //btnSave.BackColor = Color.FromArgb(44, 158, 41);
            //btnSave.ForeColor = Color.White;

            #endregion
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //加载组织
        //private void LoadOrganizationTree()
        //{
        //    string orgCode = Properties.Settings.Default.ConstOrgCode;
        //    var organizationInfo = screeningServiceClient.GetOrganizationByOrgCode(orgCode);
        //    if (organizationInfo!=null)
        //    {
        //        TreeNode rootNode = new TreeNode(organizationInfo.OrgName);
        //        rootNode.Tag = organizationInfo.OrgID;
        //        treeView1.Nodes.Add(rootNode);

        //        var list= screeningServiceClient.GetOrganizationInfoByParentOrgID(organizationInfo.OrgID);
        //        if (list!=null && list.Any())
        //        {
        //            foreach (var item in list)
        //            {
        //                TreeNode childNode = new TreeNode();
        //                childNode.Tag = item.OrgID;
        //                childNode.Text = item.OrgName;

        //                rootNode.Nodes.Add(childNode);
        //            }
        //        }
        //        treeView1.ExpandAll();
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mainfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //加载活动列表
        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    int orgId = treeView1.SelectedNode.Tag != null ? Convert.ToInt32(treeView1.SelectedNode.Tag) : 0;
        //    var resultList= screeningServiceClient.GetCottageActivityListByOrgId(orgId, 2);
        //    if (resultList!=null && resultList.Any())
        //    {
        //        listView1.Items.Clear();
        //        foreach (var item in resultList)
        //        {
        //            if (Convert.ToDateTime(item.StartTime).ToShortDateString().Equals(DateTime.Now.ToShortDateString()) || Convert.ToDateTime(item.StartTime)>DateTime.Now)
        //            {
        //                ListViewItem lvitem = new ListViewItem(item.Title);
        //                lvitem.Tag = item.CActivityID.ToString();
        //                lvitem.SubItems.AddRange(new string[] { item.StartTime.ToString()});
        //                listView1.Items.Add(lvitem);
        //            }
        //        }
        //    }
        //}

        //加载活动列表
        //private void LoadActivity()
        //{
        //    int orgId = Properties.Settings.Default.ConstOrgCode;
        //    var resultList = screeningServiceClient.GetCottageActivityListByOrgId(orgId, 2);
        //    if (resultList != null && resultList.Any())
        //    {
        //        listView1.Items.Clear();
        //        foreach (var item in resultList)
        //        {
        //            if (Convert.ToDateTime(item.StartTime).ToShortDateString().Equals(DateTime.Now.ToShortDateString()) || Convert.ToDateTime(item.StartTime) > DateTime.Now)
        //            {
        //                ListViewItem lvitem = new ListViewItem(item.Title);
        //                lvitem.Tag = item.CActivityID.ToString();
        //                lvitem.SubItems.AddRange(new string[] { item.StartTime.ToString() });
        //                listView1.Items.Add(lvitem);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 活动listview改变事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //在此处设断点，发现点击不同的Item后，此事件居然执行了2次 //第一次是取消当前Item选中状态，导致整个ListView的SelectedIndices变为0
            //第二次才将新选中的Item设置为选中状态，SelectedIndices变为1
            //如果不加listview.SelectedIndices.Count>0判断，将导致获取listview.Items[]索引超界的异常

            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection c = listView1.SelectedIndices;
                //MessageBox.Show(listView1.Items[c[0]].Tag.ToString());

                //保存活动Id及名称等
                if (listView1.Items[c[0]].Tag != null)
                {
                    //results[0] 活动Id，results[1] 小屋Id
                    string[] results=listView1.Items[c[0]].Tag.ToString().Split(',');
                    _activityId = Convert.ToInt32(results[0]);
                    _cottageOrgId = Convert.ToInt32(results[1]);

                    _txtActivName = listView1.Items[c[0]].Text;
                    _activityName = listView1.Items[c[0]].Text;

                    txtActivName.Text = listView1.Items[c[0]].Text;

                    txtCottageName.Text = listView1.Items[c[0]].SubItems[1].Text;
                    _txtCottageName = listView1.Items[c[0]].SubItems[1].Text;

                    _activityAdress = listView1.Items[c[0]].SubItems[4].Text;
                    _activityStartDate = !string.IsNullOrEmpty(listView1.Items[c[0]].SubItems[2].Text) ? Convert.ToDateTime(listView1.Items[c[0]].SubItems[2].Text) : _activityStartDate;
                    _activityEndDate = !string.IsNullOrEmpty(listView1.Items[c[0]].SubItems[3].Text) ? Convert.ToDateTime(listView1.Items[c[0]].SubItems[3].Text) : _activityEndDate;
                }
            }

            //改变高亮显示
            foreach (ListViewItem itm in listView1.Items)
            {
                itm.BackColor = SystemColors.Window;
                itm.ForeColor = Color.Black;
            }

            foreach (ListViewItem itm2 in listView1.SelectedItems)
            {
                itm2.BackColor = SystemColors.MenuHighlight;
                itm2.ForeColor = Color.White;
            }
        }

        //获取小屋
        private void BtnGetHouse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCottageName.Text))
            {
                //var resultList = screeningServiceClient.GetHealthHouseByName(txtCottageName.Text);
                var resultList = screenWebapiClient.GetHealthHouseByName(txtCottageName.Text);
                if (resultList != null && resultList.Any())
                {
                    lvCottage.Items.Clear();
                    foreach (var item in resultList)
                    {
                        ListViewItem lvItem = new ListViewItem(item.OrgName);
                        lvItem.Tag = item.OrgID;
                        lvCottage.Items.Add(lvItem);
                    }
                }
                else
                {
                    lvCottage.Items.Clear();
                    var msgBox = new CustomMessageBox("查询的小屋不存在！");
                    msgBox.ShowDialog();
                }
            }
            else
            {
                var msgBox = new CustomMessageBox("请输入小屋名称！");
                msgBox.ShowDialog();
            }
        }

        //保存小屋Id
        private void lvCottage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCottage.SelectedIndices != null && lvCottage.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection c = lvCottage.SelectedIndices;

                _cottageOrgId = lvCottage.Items[c[0]].Tag != null ? Convert.ToInt32(lvCottage.Items[c[0]].Tag) : Convert.ToInt32("1561");
                _txtCottageName = lvCottage.Items[c[0]].Text;

                txtCottageName.Text = lvCottage.Items[c[0]].Text;
            }

            //改变高亮显示
            foreach (ListViewItem itm in lvCottage.Items)
            {
                itm.BackColor = SystemColors.Window;
                itm.ForeColor = Color.Black;
            }

            foreach (ListViewItem itm2 in lvCottage.SelectedItems)
            {
                itm2.BackColor = SystemColors.MenuHighlight;
                itm2.ForeColor = Color.White;
            }
        }

        ////保存设置
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (rdAD.Checked) Properties.Settings.Default.ScreenSet = 1;
        //    if (rdNaocz.Checked) Properties.Settings.Default.ScreenSet = 2;
        //    if (rdZaoai.Checked) Properties.Settings.Default.ScreenSet = 3;
        //    if (rdKangfu.Checked) Properties.Settings.Default.ScreenSet = 4;
        //    Properties.Settings.Default.Save();

        //    if (MessageBox.Show("是否退出当前页面？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        int iWhichQuestion = Properties.Settings.Default.ScreenSet;
        //        switch (iWhichQuestion)
        //        {
        //            case 1://老年痴呆筛查
        //                AD.FirstFrm frmAdFirst = new AD.FirstFrm();
        //                frmAdFirst.TopMost = false;
        //                frmAdFirst.Show();
        //                break;
        //            case 2: //脑卒中筛查
        //                Naocuzhong.FirstFrm naoFirst = new Naocuzhong.FirstFrm();
        //                naoFirst.TopMost = false;
        //                naoFirst.Show();
        //                break;
        //            case 3://早癌筛查
        //                Zaoai.ScreeningZaoaiSelect frmZaoAi = new Zaoai.ScreeningZaoaiSelect();
        //                frmZaoAi.TopMost = false;
        //                frmZaoAi.Show();
        //                break;
        //            case 4://工伤康复筛查
        //                Kangfu.ScreeningSelect frmKangfu = new Kangfu.ScreeningSelect();
        //                frmKangfu.TopMost = false;
        //                frmKangfu.Show();
        //                break;
        //            default:
        //                break;
        //        }

        //        this.Hide();
        //    }


        //}

        /// <summary>
        /// 查询活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchActiv_Click(object sender, EventArgs e)
        {
            _pageIndex = 1;
            _searchName = txtActivName.Text.Trim();
            GetActivityPaging(_searchName, _pageIndex, _pageSize);
        }

        private void GetActivityPaging(string name,int pageIndex,int pageSize)
        {
            if (string.IsNullOrEmpty(name))
            {
                //lblResultActitvty.Text = "请输入活动标题！";
                var msgBox = new CustomMessageBox("请输入活动主题！");
                msgBox.ShowDialog();
                return;
            }

            //var resultList = screeningServiceClient.GetCottageActivityByName(name);
            var mCAPaging = screenWebapiClient.GetCottageActivityByName(name,pageIndex,pageSize);
            if (mCAPaging != null && mCAPaging.TotalCount > 0)
            {
                //分页相关
                _pageCount = mCAPaging.TotalPage;
                _pageIndex = mCAPaging.PageIndex;
                lblPageMsg.Text = _pageIndex + "/" + _pageCount;
                lblTotalMsg.Text = mCAPaging.TotalCount.ToString();

                listView1.Items.Clear();
                //lblResultActitvty.Text = "输入关键字，点击【查询】按钮";
                foreach (var item in mCAPaging.MCottageActivities)
                {
                    ListViewItem lvitem = new ListViewItem(item.Title);
                    //保存活动Id加小屋Id
                    lvitem.Tag = item.CActivityID + "," + item.OrgID;
                    lvitem.SubItems.AddRange(new string[]
                    {
                        item.OrgName, 
                        Convert.ToDateTime(item.StartTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        Convert.ToDateTime(item.EndTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        item.Address
                    });
                    listView1.Items.Add(lvitem);
                }

                //设置按钮状态
                SetBtnStatus();
            }
            else
            {
                listView1.Items.Clear();
                //lblResultActitvty.Text = "查询的活动不存在或已经过期！";
                
                //分页相关
                _pageIndex = 1;
                _pageCount = 0;
                //设置按钮状态
                SetBtnStatus();
                lblPageMsg.Text = string.Empty;
                lblTotalMsg.Text = string.Empty;

                var msgBox = new CustomMessageBox("查询的活动不存在或已经过期！");
                msgBox.ShowDialog();
            }
        }

        private void rbOperator_CheckedChanged(object sender, EventArgs e)
        {
            txtDrAccount.Enabled = true;
            txtActivName.Enabled = true;
            txtCottageName.Enabled = true;
            listView1.Enabled = true;
            lvCottage.Enabled = true;
            btnSearchActiv.Enabled = true;
            BtnGetHouse.Enabled = true;
            #region 暂时不用
            //btnFirst.Enabled = true;
            //btnBack.Enabled = true;
            //btnNext.Enabled = true;
            //btnLast.Enabled = true; 
            #endregion
            txtSkip.Enabled = true;
            btnSkip.Enabled = true;
        }

        private void rbVisitor_CheckedChanged(object sender, EventArgs e)
        {
            txtDrAccount.Enabled = false;
            txtActivName.Enabled = false;
            txtCottageName.Enabled = false;
            listView1.Enabled = false;
            lvCottage.Enabled = false;
            btnSearchActiv.Enabled = false;
            BtnGetHouse.Enabled = false;
            #region 暂时不用
            //btnFirst.Enabled = false;
            //btnBack.Enabled = false;
            //btnNext.Enabled = false;
            //btnLast.Enabled = false; 
            #endregion
            txtSkip.Enabled = false;
            btnSkip.Enabled = false;
        }

        //召唤处理历史数据窗体
        private int iBackDoor = 0;
        private void callHisDataManagePanel_MouseClick(object sender, MouseEventArgs e)
        {
            iBackDoor++;
            if (iBackDoor >= 5)
            {
                HistoryDataManager historyDataManager = new HistoryDataManager();
                historyDataManager.TopMost = false;
                historyDataManager.Show();
                iBackDoor = 0;
            }
        }

        //设置按钮状态
        private void SetBtnStatus()
        {
            if (_pageIndex <= 1)
            {
                btnFirst.Enabled = false;
                btnBack.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnBack.Enabled = true;
            }
            if (_pageIndex >= _pageCount)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
        }

        //文本框只能输入数字处理
        private void txtSkip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }
        //首页
        private void btnFirst_Click(object sender, EventArgs e)
        {
            _pageIndex = 1;
            GetActivityPaging(_searchName, _pageIndex, _pageSize);
        }
        //上一页
        private void btnBack_Click(object sender, EventArgs e)
        {
            _pageIndex--;
            GetActivityPaging(_searchName, _pageIndex, _pageSize);
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            _pageIndex++;
            GetActivityPaging(_searchName, _pageIndex, _pageSize);
        }
        //末页
        private void btnLast_Click(object sender, EventArgs e)
        {
            _pageIndex = _pageCount;
            GetActivityPaging(_searchName, _pageIndex, _pageSize);
        }
        //跳转
        private void btnSkip_Click(object sender, EventArgs e)
        {
            var skipNum = !string.IsNullOrEmpty(txtSkip.Text.Trim()) ? int.Parse(txtSkip.Text.Trim()) : 1;
            if (skipNum < 1 || skipNum > _pageCount)
            {
                //MessageBox.Show("页码不在范围内！");
                var msgBox = new CustomMessageBox("页码不在范围内！");
                msgBox.ShowDialog();
                return;
            }
            _pageIndex = skipNum;
            GetActivityPaging(_searchName, _pageIndex, _pageSize);
        }

        //去掉groupbox边框
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
        }

        private void txtDrAccount_Click(object sender, EventArgs e)
        {
            //KeyboardManager.ShowInputPanel();
        }

        private void txtDrAccount_Leave(object sender, EventArgs e)
        {
            //KeyboardManager.HideInputPanel();
        }

        private void txtActivName_Click(object sender, EventArgs e)
        {
            //KeyboardManager.ShowInputPanel();
        }

        private void txtActivName_Leave(object sender, EventArgs e)
        {
            //KeyboardManager.HideInputPanel();
        }

    }
}
