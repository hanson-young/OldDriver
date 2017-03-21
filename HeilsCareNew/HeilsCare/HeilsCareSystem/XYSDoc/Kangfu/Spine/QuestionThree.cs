using System;
using System.Drawing;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    public partial class QuestionThree : SpineBaseForm
    {
        public QuestionThree()
        {
            InitializeComponent();
            Question = new[]
            {
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".5", rdoQ1AnswerYes, rdoQ1AnswerNo),
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".6", rdoQ2AnswerYes, rdoQ2AnswerNo),
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".7", rdoQ3AnswerYes, rdoQ3AnswerNo),
            };
            lblQuestion3.Select(12, 2);
            lblQuestion3.SelectionColor = Color.Red;
        }


        protected override void btnBefore_Click(object sender, EventArgs e)
        {
            //back to last form
            TurnToForm(new QuestionTwo());
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            //to do save user's answer and turn to the next form
            base.btnNext_Click(sender, e);
            //turn to the next form
            TurnToForm(new QuestionFour());
        }
    }
}
