using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.THAH
{
    public partial class ThahOne : BaseForm
    {
        public ThahOne()
        {
            InitializeComponent();
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreenOtherSelect screenOtherSelect = new ScreenOtherSelect();
            screenOtherSelect.TopMost = false;
            screenOtherSelect.Show();
            Close();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //上一步
        private void btnBefore_Click(object sender, EventArgs e)
        {
            btnBack_Click(this, e);
        }
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            //判断
            if ((!rbQ1A.Checked && !rbQ1B.Checked)||string.IsNullOrEmpty(txtQ2.Text))
            {
                var msgBox=new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }
            if (double.Parse(txtQ2.Text) < 6 || double.Parse(txtQ2.Text) > 17)
            {
                var msgBox = new CustomMessageBox("年龄范围为6-17周岁！");
                msgBox.ShowDialog();
                txtQ2.Text = string.Empty;
                txtQ2.Focus();
                return;
            }


            //保存答案
            //第一题
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail
            {
                QuestionResult = rbQ1A.Checked ? "A," : "B,",
                QuestionCode = QuestionnaireCode.Thah + ".1",
                PQuestionCode = QuestionnaireCode.Thah + ".1",
                QuestionType = 1,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.Thah);

            //第二题
            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail
            {
                QuestionResult = (int)double.Parse(txtQ2.Text) + ",",
                QuestionCode = QuestionnaireCode.Thah + ".2",
                PQuestionCode = QuestionnaireCode.Thah + ".2",
                QuestionType=3,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question2, QuestionnaireCode.Thah);

            //跳转
            ThahTwo thahTwo = new ThahTwo { TopMost = false };
            thahTwo.Show();
            Close();
        }
        //加载
        private void ThahOne_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".1");
            if (answer1.Contains("A")) { rbQ1A.Checked = true; }
            if (answer1.Contains("B")) { rbQ1B.Checked = true; }

            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".2");
            txtQ2.Text = !string.IsNullOrEmpty(answer2)?answer2.Substring(0,answer2.Length-1):string.Empty;
        }

        //数字键盘
        private void txtQ2_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }
        //判断
        double age = 0;
        private void txtQ2_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ2.Text))
            {
                if (!double.TryParse(txtQ2.Text, out age))
                {
                    var msgBox=new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtQ2.Text = string.Empty;
                    txtQ2.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        private void txtQ2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ2.Text) && age>0)
               txtQ2.Text = age.ToString();
        }
    }
}
