using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.THAH
{
    public partial class ThahThree : BaseForm
    {
        public ThahThree()
        {
            InitializeComponent();
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            var screenOtherSelect = new ScreenOtherSelect { TopMost = false };
            screenOtherSelect.Show();
            Close();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            var quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //上一页
        private void btnBefore_Click(object sender, EventArgs e)
        {
            var thahTwo = new ThahTwo{ TopMost = false };
            thahTwo.Show();
            Close();
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //判断
            if (string.IsNullOrEmpty(txtQ6A.Text) || string.IsNullOrEmpty(txtQ6B.Text) || (!rbQ7A.Checked && !rbQ7B.Checked && !rbQ7C.Checked) || string.IsNullOrEmpty(txtQ7D.Text))
            {
                var msgBox = new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }
            if (double.Parse(txtQ6A.Text)<=0)
            {
                var msgBox = new CustomMessageBox("收缩压不能为0！");
                msgBox.ShowDialog();
                return;
            }
            if (double.Parse(txtQ6B.Text) <= 0)
            {
                var msgBox = new CustomMessageBox("舒张压不能为0！");
                msgBox.ShowDialog();
                return;
            }
            if (double.Parse(txtQ6B.Text) > double.Parse(txtQ6A.Text))
            {
                var msgBox = new CustomMessageBox("舒张压不能大于收缩压！");
                msgBox.ShowDialog();
                return;
            }
            if (double.Parse(txtQ7D.Text) <= 0)
            {
                var msgBox = new CustomMessageBox("血糖值不能为0！");
                msgBox.ShowDialog();
                return;
            }

            //保存答案
            //第六题
            M_QuestionnaireResultDetail question6 = new M_QuestionnaireResultDetail
            {
                QuestionResult = (int)double.Parse(txtQ6A.Text) + "," + (int)double.Parse(txtQ6B.Text) + ",",
                QuestionCode = QuestionnaireCode.Thah + ".6",
                PQuestionCode = QuestionnaireCode.Thah + ".6",
                QuestionType = 3,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question6, QuestionnaireCode.Thah);

            //第七题
            M_QuestionnaireResultDetail question7 = new M_QuestionnaireResultDetail
            {
                QuestionResult = (rbQ7A.Checked ? "A," : (rbQ7B.Checked ? "B," : "C,")) + Math.Round(double.Parse(txtQ7D.Text), 1) + ",",
                QuestionCode = QuestionnaireCode.Thah + ".7",
                PQuestionCode = QuestionnaireCode.Thah + ".7",
                QuestionType = 1,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question7, QuestionnaireCode.Thah);

            //跳转
            var thahFour = new ThahFour { TopMost = false };
            thahFour.Show();
            Close();
        }
        //加载
        private void ThahThree_Load(object sender, EventArgs e)
        {
            string answer6 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".6");
            var result = !string.IsNullOrEmpty(answer6) ? answer6.Substring(0, answer6.Length - 1) : string.Empty;
            if (!string.IsNullOrEmpty(result))
            {
                var strArray= result.Split(',');
                txtQ6A.Text = strArray[0];
                txtQ6B.Text = strArray[1];
            }

            string answer7 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".7");
            if (answer7.Contains("A"))
                rbQ7A.Checked = true;
            if (answer7.Contains("B"))
                rbQ7B.Checked = true;
            if (answer7.Contains("C"))
                rbQ7C.Checked = true;
            if (!string.IsNullOrEmpty(answer7))
            {
                var strArray = answer7.Substring(0, answer7.Length - 1).Split(',');
                txtQ7D.Text = strArray[1];
            }
        }
        //数字键盘
        private void txtQ6A_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        private void txtQ6B_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        double num6a = 0;
        private void txtQ6A_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ6A.Text))
            {
                if (!double.TryParse(txtQ6A.Text, out num6a))
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtQ6A.Text = string.Empty;
                    txtQ6A.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        double num6b = 0;
        private void txtQ6B_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ6B.Text))
            {
                if (!double.TryParse(txtQ6B.Text, out num6b))
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtQ6B.Text = string.Empty;
                    txtQ6B.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }
        //数字键盘
        private void txtQ7D_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        double num7d = 0;
        private void txtQ7D_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ7D.Text))
            {
                if (!double.TryParse(txtQ7D.Text, out num7d))
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtQ7D.Text = string.Empty;
                    txtQ7D.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        private void txtQ6A_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ6A.Text) && num6a>0)
                txtQ6A.Text = num6a.ToString();
        }

        private void txtQ6B_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ6B.Text) && num6b>0)
                txtQ6B.Text = num6b.ToString();
        }

        private void txtQ7D_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ7D.Text) && num7d>0)
                txtQ7D.Text = num7d.ToString();
        }

        
    }
}
