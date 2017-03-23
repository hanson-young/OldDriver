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
    public partial class ThahFive : BaseForm
    {
        public ThahFive()
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
            var thahFour = new ThahFour { TopMost = false };
            thahFour.Show();
            Close();
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //判断
            if (!cbQ10A.Checked && !cbQ10B.Checked && !cbQ10C.Checked && !cbQ10D.Checked && !cbQ10E.Checked &&
                !cbQ10F.Checked && !cbQ10G.Checked)
            {
                var msgBox = new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }
            //判断
            if (!cbQ11A.Checked && !cbQ11B.Checked && !cbQ11C.Checked && !cbQ11D.Checked && !cbQ11E.Checked &&
                !cbQ11F.Checked && !cbQ11G.Checked)
            {
                var msgBox = new CustomMessageBox("请答完本页所有题目再进入下一题！");
                msgBox.ShowDialog();
                return;
            }

            //保存答案
            //第十题
            var strResult10 = string.Empty;
            if (cbQ10A.Checked)
                strResult10 += "A,";
            if (cbQ10B.Checked)
                strResult10 += "B,";
            if (cbQ10C.Checked)
                strResult10 += "C,";
            if (cbQ10D.Checked)
                strResult10 += "D,";
            if (cbQ10E.Checked)
                strResult10 += "E,";
            if (cbQ10F.Checked)
                strResult10 += "F,";
            if (cbQ10G.Checked)
                strResult10 += "G,";
            M_QuestionnaireResultDetail question10 = new M_QuestionnaireResultDetail
            {
                QuestionResult = strResult10,
                QuestionCode = QuestionnaireCode.Thah + ".10",
                PQuestionCode = QuestionnaireCode.Thah + ".10",
                QuestionType = 2,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question10, QuestionnaireCode.Thah);

            //第十一题
            var strResult11 = string.Empty;
            if (cbQ11A.Checked)
                strResult11 += "A,";
            if (cbQ11B.Checked)
                strResult11 += "B,";
            if (cbQ11C.Checked)
                strResult11 += "C,";
            if (cbQ11D.Checked)
                strResult11 += "D,";
            if (cbQ11E.Checked)
                strResult11 += "E,";
            if (cbQ11F.Checked)
                strResult11 += "F,";
            if (cbQ11G.Checked)
                strResult11 += "G,";
            M_QuestionnaireResultDetail question11 = new M_QuestionnaireResultDetail
            {
                QuestionResult = strResult11,
                QuestionCode = QuestionnaireCode.Thah + ".11",
                PQuestionCode = QuestionnaireCode.Thah + ".11",
                QuestionType = 2,
                QuestionScore = 0,
                PQuestionWeightScore = 0
            };
            ClientInfo.AddQuestionToQuestionnaire(question11, QuestionnaireCode.Thah); 

            //跳转
            var thahSix=new ThahSix{TopMost = false};
            thahSix.Show();
            Close();
        }
        //加载
        private void ThahSix_Load(object sender, EventArgs e)
        {
            string answer10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".10");
            if (answer10.Contains("A"))
                cbQ10A.Checked = true;
            if (answer10.Contains("B"))
                cbQ10B.Checked = true;
            if (answer10.Contains("C"))
                cbQ10C.Checked = true;
            if (answer10.Contains("D"))
                cbQ10D.Checked = true;
            if (answer10.Contains("E"))
                cbQ10E.Checked = true;
            if (answer10.Contains("F"))
                cbQ10F.Checked = true;
            if (answer10.Contains("G"))
                cbQ10G.Checked = true;

            string answer11 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".11");
            if (answer11.Contains("A"))
                cbQ11A.Checked = true;
            if (answer11.Contains("B"))
                cbQ11B.Checked = true;
            if (answer11.Contains("C"))
                cbQ11C.Checked = true;
            if (answer11.Contains("D"))
                cbQ11D.Checked = true;
            if (answer11.Contains("E"))
                cbQ11E.Checked = true;
            if (answer11.Contains("F"))
                cbQ11F.Checked = true;
            if (answer11.Contains("G"))
                cbQ11G.Checked = true;
        }
    }
}
