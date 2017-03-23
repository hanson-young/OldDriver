using System;
using System.Linq;

namespace XYS.Remp.Screening.Public
{
    public partial class QuestionnaireBaseForm : BaseForm
    {
        public readonly string Code;
        public VM_Question[] Question;

        public QuestionnaireBaseForm()
        {
            InitializeComponent();
        }

        public QuestionnaireBaseForm(string code, string title)
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
        public void TurnToForm(QuestionnaireBaseForm form)
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
        public virtual BaseForm GetParentForm()
        {
            return new BaseForm();
        }
        #endregion
    }
}
