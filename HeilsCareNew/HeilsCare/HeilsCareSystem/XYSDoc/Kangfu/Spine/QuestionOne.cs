using System;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    public partial class QuestionOne : SpineBaseForm
    {
        public QuestionOne()
        {
            InitializeComponent();
            Question = new[]
            {
                new Tuple<string, CustomRadioButton, CustomRadioButton>(Code + ".1", rdoAnswerYes, rdoAnswerNo),
            };
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            //to do save user's answer 
            base.btnNext_Click(sender, e);
            //turn to the next form
            TurnToForm(new QuestionTwo());
        }
    }
}
