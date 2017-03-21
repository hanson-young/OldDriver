using System;
using System.Linq;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    public partial class SpineBaseForm : BaseForm
    {
        protected SpineBaseForm()
        {
            InitializeComponent();
        }

        protected static readonly string Code = QuestionnaireCode.KangFuSpine;
        protected Tuple<string, CustomRadioButton, CustomRadioButton>[] Question;

        #region 切换窗口
        /// <summary>
        /// 切换窗口
        /// </summary>
        /// <param name="form"></param>
        public void TurnToForm(SpineBaseForm form)
        {
            form.TopMost = false;
            form.ShowDialog();
            Close();
        }

        #endregion
        #region 退出按钮事件
        /// <summary>
        /// 退出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);

            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this);
            quitComfirmFrm.ShowDialog();
        }

        #endregion
        #region 返回按钮事件
        /// <summary>
        /// 返回按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmMain = new ScreeningSelect { TopMost = false };
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
        protected virtual void btnNext_Click(object sender, EventArgs e)
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
        protected virtual void btnBefore_Click(object sender, EventArgs e)
        {
        }

        #endregion
        #region 窗口加载事件
        /// <summary>
        /// 窗口加载事件(必须在子类重写)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FormLoadEven(object sender, EventArgs e)
        {
            BeginInvoke(new Action(LoadAnswer));
        }

        #endregion
        #region 加载答案
        /// <summary>
        /// 加载答案
        /// </summary>
        protected virtual void LoadAnswer()
        {
            if (Question == null || !Question.Any()) return;
            var answer = Question.Select(p => ClientInfo.GetAnswerByCode(Code, p.Item1)).ToArray();
            for (int i = 0, length = answer.Length; i < length; i++)
            {
                if (string.IsNullOrEmpty(answer[i].Trim())) continue;
                var question = Question[i];
                if (answer[i].Contains("A")) question.Item2.Checked = true;
                else if (answer[i].Contains("B")) question.Item3.Checked = true;
            }
        }
        #endregion

        #region 保存答案
        /// <summary>
        /// 保存答案
        /// </summary>
        protected virtual void SavaAnswer()
        {
            if (Question == null || !Question.Any()) return;
            foreach (var item in Question)
            {
                var result = item.Item2.Checked ? "A," : item.Item3.Checked ? "B," : string.Empty;
                var question = new M_QuestionnaireResultDetail
                {
                    QuestionResult = result,
                    QuestionScore = result.Contains("A") ? 10 : 0,
                    QuestionType = 1,
                    QuestionCode = item.Item1
                };
                ClientInfo.AddQuestionToQuestionnaire(question, Code);
            }
        }

        #endregion
    }
}
