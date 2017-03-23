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
    public partial class ThahSix : BaseForm
    {
        public ThahSix()
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
            var thahFive = new ThahFive { TopMost = false };
            thahFive.Show();
            Close();
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //判断
            if (!rbQ12A.Checked && !rbQ12B.Checked && !rbQ12C.Checked && !rbQ12D.Checked)
            {
                var msgBox = new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }
            //判断
            if (!cbQ13A.Checked && !cbQ13B.Checked && !cbQ13C.Checked && !cbQ13D.Checked && !cbQ13E.Checked &&
                !cbQ13F.Checked)
            {
                var msgBox = new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }

            //保存答案
            //第十二题
            var strResult12=String.Empty;
            if (rbQ12A.Checked)
                strResult12 = "A,";
            if (rbQ12B.Checked)
                strResult12 = "B,";
            if (rbQ12C.Checked)
                strResult12 = "C,";
            if (rbQ12D.Checked)
                strResult12 = "D,";
            M_QuestionnaireResultDetail question12 = new M_QuestionnaireResultDetail
            {
                QuestionResult = strResult12,
                QuestionCode = QuestionnaireCode.Thah + ".12",
                PQuestionCode = QuestionnaireCode.Thah + ".12",
                QuestionType = 1,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question12, QuestionnaireCode.Thah);

            //第十三题
            var strResult13 = string.Empty;
            if (cbQ13A.Checked)
                strResult13 += "A,";
            if (cbQ13B.Checked)
                strResult13 += "B,";
            if (cbQ13C.Checked)
                strResult13 += "C,";
            if (cbQ13D.Checked)
                strResult13 += "D,";
            if (cbQ13E.Checked)
                strResult13 += "E,";
            if (cbQ13F.Checked)
                strResult13 += "F,";
            M_QuestionnaireResultDetail question13 = new M_QuestionnaireResultDetail
            {
                QuestionResult = strResult13,
                QuestionCode = QuestionnaireCode.Thah + ".13",
                PQuestionCode = QuestionnaireCode.Thah + ".13",
                QuestionType = 2,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question13, QuestionnaireCode.Thah); 

            //跳转
            var thahResult = new ThahResult { TopMost = false };
            thahResult.Show();
            Close();
        }
        //加载
        private void ThahEight_Load(object sender, EventArgs e)
        {
            string answer12 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".12");
            if (answer12.Contains("A"))
                rbQ12A.Checked = true;
            if (answer12.Contains("B"))
                rbQ12B.Checked = true;
            if (answer12.Contains("C"))
                rbQ12C.Checked = true;
            if (answer12.Contains("D"))
                rbQ12D.Checked = true;

            string answer13 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".13");
            if (answer13.Contains("A"))
                cbQ13A.Checked = true;
            if (answer13.Contains("B"))
                cbQ13B.Checked = true;
            if (answer13.Contains("C"))
                cbQ13C.Checked = true;
            if (answer13.Contains("D"))
                cbQ13D.Checked = true;
            if (answer13.Contains("E"))
                cbQ13E.Checked = true;
            if (answer13.Contains("F"))
                cbQ13F.Checked = true;
        }
    }
}
