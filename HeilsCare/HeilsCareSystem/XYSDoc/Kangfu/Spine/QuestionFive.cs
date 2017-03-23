using System;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    public partial class QuestionFive : SpineBaseForm
    {
        public QuestionFive()
        {
            InitializeComponent();
            Question = new[]
            {
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".11", rdoQ1AnswerYes, rdoQ1AnswerNo),
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".12", rdoQ2AnswerYes, rdoQ2AnswerNo)
            };
        }

        protected override void btnBefore_Click(object sender, EventArgs e)
        {
            //back to last form
            TurnToForm(new QuestionFour());
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            //to do save user's answer and turn to the next form
            base.btnNext_Click(sender, e);
            //turn to the next form
            TurnToForm(new Result());
        }
    }
}
