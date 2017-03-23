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
    public partial class ThahFour : BaseForm
    {
        public ThahFour()
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
            var thahThree = new ThahThree { TopMost = false };
            thahThree.Show();
            Close();
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //判断
            if (!rbQ8A.Checked && !rbQ8B.Checked && !rbQ8C.Checked && !rbQ8D.Checked && !rbQ8E.Checked)
            {
                var msgBox = new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }
            if (!rbQ9A.Checked && !rbQ9B.Checked && !rbQ9C.Checked && !rbQ9D.Checked && !rbQ9E.Checked)
            {
                var msgBox = new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }

            //保存答案
            //第八题
            var strResult8 = string.Empty;
            if (rbQ8A.Checked)
                strResult8 = "A,";
            if (rbQ8B.Checked)
                strResult8 = "B,";
            if (rbQ8C.Checked)
                strResult8 = "C,";
            if (rbQ8D.Checked)
                strResult8 = "D,";
            if (rbQ8E.Checked)
                strResult8 = "E,";
            M_QuestionnaireResultDetail question8 = new M_QuestionnaireResultDetail
            {
                QuestionResult = strResult8,
                QuestionCode = QuestionnaireCode.Thah + ".8",
                PQuestionCode = QuestionnaireCode.Thah + ".8",
                QuestionType = 1,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question8, QuestionnaireCode.Thah);

            //第九题
            var strResult9 = string.Empty;
            if (rbQ9A.Checked)
                strResult9 = "A,";
            if (rbQ9B.Checked)
                strResult9 = "B,";
            if (rbQ9C.Checked)
                strResult9 = "C,";
            if (rbQ9D.Checked)
                strResult9 = "D,";
            if (rbQ9E.Checked)
                strResult9 = "E,";
            M_QuestionnaireResultDetail question9 = new M_QuestionnaireResultDetail
            {
                QuestionResult = strResult9,
                QuestionCode = QuestionnaireCode.Thah + ".9",
                PQuestionCode = QuestionnaireCode.Thah + ".9",
                QuestionType = 1,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question9, QuestionnaireCode.Thah);

            var thahFive = new ThahFive { TopMost = false };
            thahFive.Show();
            Close();
        }
        //加载
        private void ThahFive_Load(object sender, EventArgs e)
        {
            string answer8 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".8");
            if (answer8.Contains("A"))
                rbQ8A.Checked = true;
            if (answer8.Contains("B"))
                rbQ8B.Checked = true;
            if (answer8.Contains("C"))
                rbQ8C.Checked = true;
            if (answer8.Contains("D"))
                rbQ8D.Checked = true;
            if (answer8.Contains("E"))
                rbQ8E.Checked = true;

            string answer9 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".9");
            if (answer9.Contains("A"))
                rbQ9A.Checked = true;
            if (answer9.Contains("B"))
                rbQ9B.Checked = true;
            if (answer9.Contains("C"))
                rbQ9C.Checked = true;
            if (answer9.Contains("D"))
                rbQ9D.Checked = true;
            if (answer9.Contains("E"))
                rbQ9E.Checked = true;
        }
    }
}
