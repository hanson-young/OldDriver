using System;
using System.Drawing;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    public partial class QuestionFour : SpineBaseForm
    {
        public QuestionFour()
        {
            InitializeComponent();
            Question = new[]
            {
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".8", rdoQ1AnswerYes, rdoQ1AnswerNo),
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".9", rdoQ2AnswerYes, rdoQ2AnswerNo),
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".10", rdoQ3AnswerYes, rdoQ3AnswerNo),
            };
            lblQueation2.Select(14, 3);
            lblQueation2.SelectionColor = Color.Red;
        }

        protected override void btnBefore_Click(object sender, EventArgs e)
        {
            //back to last form
            TurnToForm(new QuestionThree());
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            //to do save user's answer
            base.btnNext_Click(sender, e);
            //turn to the next form
            TurnToForm(new QuestionFive());
        }
    }
}
