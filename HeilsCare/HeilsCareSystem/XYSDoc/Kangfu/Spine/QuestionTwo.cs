using System;
using System.Drawing;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    public partial class QuestionTwo : SpineBaseForm
    {
        public QuestionTwo()
        {
            InitializeComponent();
            Question = new[]
            {
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".2", rdoQ1AnswerYes, rdoQ1AnswerNo),
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".3", rdoQ2AnswerYes, rdoQ2AnswerNo),
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".4", rdoQ3AnswerYes, rdoQ3AnswerNo)
            };
            lblQuestion1.Select(6,2);
            lblQuestion1.SelectionColor=Color.Red;
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            //to do save user's answer 
            base.btnNext_Click(sender, e);
            //turn to the next form
            TurnToForm(new QuestionThree());
        }

        protected override void btnBefore_Click(object sender, EventArgs e)
        {
            //back to last form
            TurnToForm(new QuestionOne());
        }
    }
}
