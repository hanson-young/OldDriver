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
    public partial class ThahTwo : BaseForm
    {
        public ThahTwo()
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
            var thahOne = new ThahOne { TopMost = false };
            thahOne.Show();
            Close();
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //判断
            if (string.IsNullOrEmpty(txtQ3.Text) || string.IsNullOrEmpty(txtQ4.Text) || string.IsNullOrEmpty(txtQ5.Text))
            {
                var msgBox = new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }
            if (double.Parse(txtQ3.Text) <= 0)
            {
                var msgBox = new CustomMessageBox("身高不能为零！");
                msgBox.ShowDialog();
                return;
            }
            if (double.Parse(txtQ4.Text) <= 0)
            {
                var msgBox = new CustomMessageBox("体重不能为零！");
                msgBox.ShowDialog();
                return;
            }
            if (double.Parse(txtQ5.Text) <= 0)
            {
                var msgBox = new CustomMessageBox("BMI指数不能为零！");
                msgBox.ShowDialog();
                return;
            }

            //保存答案
            //第三题
            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail
            {
                QuestionResult = (int)double.Parse(txtQ3.Text) + ",",
                QuestionCode = QuestionnaireCode.Thah + ".3",
                PQuestionCode = QuestionnaireCode.Thah + ".3",
                QuestionType = 3,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question3, QuestionnaireCode.Thah);

            //第四题
            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail
            {
                QuestionResult = Math.Round(double.Parse(txtQ4.Text), 1) + ",",
                QuestionCode = QuestionnaireCode.Thah + ".4",
                PQuestionCode = QuestionnaireCode.Thah + ".4",
                QuestionType = 3,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question4, QuestionnaireCode.Thah);

            //第五题
            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail
            {
                QuestionResult = Math.Round(double.Parse(txtQ5.Text), 1) + ",",
                QuestionCode = QuestionnaireCode.Thah + ".5",
                PQuestionCode = QuestionnaireCode.Thah + ".5",
                QuestionType = 3,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question5, QuestionnaireCode.Thah);

            //跳转
            var thahThree = new ThahThree { TopMost = false };
            thahThree.Show();
            Close();
        }
        //加载
        private void ThahTwo_Load(object sender, EventArgs e)
        {
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".3");
            txtQ3.Text = !string.IsNullOrEmpty(answer3) ? answer3.Substring(0, answer3.Length - 1) : string.Empty;

            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".4");
            txtQ4.Text = !string.IsNullOrEmpty(answer4) ? answer4.Substring(0, answer4.Length - 1) : string.Empty;

            string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".5");
            txtQ5.Text = !string.IsNullOrEmpty(answer5) ? answer5.Substring(0, answer5.Length - 1) : string.Empty;
        }
        //数字键盘
        private void txtQ3_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        private void txtQ4_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        private void txtQ5_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }
        //计算BMI
        //公式：体质指数（BMI）=体重（kg）÷ 身高²（m）
        private void txtQ4_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ4.Text) && weight>0)
            {
                txtQ4.Text = weight.ToString();
            }
            
            if (!string.IsNullOrEmpty(txtQ3.Text) && !string.IsNullOrEmpty(txtQ4.Text))
            {
                double subheight = (int) double.Parse(txtQ3.Text)*0.01;
                double subweight = Math.Round(double.Parse(txtQ4.Text), 1);
                double bmiResult= Math.Round((subweight / (subheight * subheight)), 1);
                txtQ5.Text = bmiResult.ToString();
                bmi = bmiResult;
            }
            else
            {
                var msgBox = new CustomMessageBox("请填写身高与体重！");
                msgBox.ShowDialog();
                return;
            }
        }

        double height = 0;
        private void txtQ3_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ3.Text))
            {
                if (!double.TryParse(txtQ3.Text, out height))
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtQ3.Text = string.Empty;
                    txtQ3.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        double weight = 0;
        private void txtQ4_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ4.Text))
            {
                if (!double.TryParse(txtQ4.Text, out weight))
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtQ4.Text = string.Empty;
                    txtQ4.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        double bmi = 0;
        private void txtQ5_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ5.Text))
            {
                if (!double.TryParse(txtQ5.Text, out bmi))
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtQ5.Text = string.Empty;
                    txtQ5.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        private void txtQ3_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ3.Text) && height>0)
            {
                txtQ3.Text = ((int)height).ToString();
            }
            
            if (!string.IsNullOrEmpty(txtQ3.Text) && !string.IsNullOrEmpty(txtQ4.Text))
            {
                double subheight = (int)double.Parse(txtQ3.Text) * 0.01;
                double subweight = Math.Round(double.Parse(txtQ4.Text), 1);
                txtQ5.Text = Math.Round((subweight / (subheight * subheight)), 1).ToString();
            }
        }

        private void txtQ5_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ5.Text) && bmi>0)
               txtQ5.Text = bmi.ToString();
        }
    }
}
