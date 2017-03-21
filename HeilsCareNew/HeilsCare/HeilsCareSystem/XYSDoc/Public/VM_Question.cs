using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;

namespace XYS.Remp.Screening.Public
{
    public class VM_Question
    {
        /// <summary>
        /// 题目类型
        /// 0-选项
        /// 1-单选
        /// 2-多选
        /// 3-填空
        /// 4-填空加单选
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 题目代号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 单选框们
        /// </summary>
        public RadioButton[] Radios { get; set; }

        /// <summary>
        /// 复选框们
        /// </summary>
        public CheckBox[] CheckBoxs { get; set; }

        /// <summary>
        /// 输入框们
        /// </summary>
        public TextBox[] Texts { get; set; }

        /// <summary>
        /// 输入框
        /// </summary>
        public TextBox Text { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 得分上限
        /// </summary>
        public int Max { get; set; }

        //---by hp---
        public VM_Question(string code,TextBox[] texts, params RadioButton[] radio)
        {
            Code = code;
            Texts = texts;
            Radios = radio;
            Type = 4;
        }
        //---by hp end---

        public VM_Question(string code, params RadioButton[] radio)
        {
            Code = code;
            Radios = radio;
            Type = 1;
        }

        public VM_Question(string code, params CheckBox[] checkBox)
        {
            Code = code;
            CheckBoxs = checkBox;
            Type = 2;
        }

        public VM_Question(string code, TextBox text)
        {
            Code = code;
            Text = text;
            Type = 3;
        }

        public M_QuestionnaireResultDetail ToResultDetail()
        {
            M_QuestionnaireResultDetail question;
            switch (Type)
            {
                case 1:
                    question = RadioToDetail();
                    break;
                case 2:
                    question = CheckBoxToDetail();
                    break;
                case 3:
                    question = TextToDetail();
                    break;
                //---by hp---
                case 4:
                    question = TextAndRadioToDetail();
                    break;
                //---by hp end---
                default:
                    question = null;
                    break;
            }
            return question;
        }

        //---by hp---
        private M_QuestionnaireResultDetail TextAndRadioToDetail()
        {
            if (Texts == null || Texts.Any(p => string.IsNullOrEmpty(p.Text))) 
                return null;
            if (Radios == null || !Radios.Any()) 
                return null;
            var score = 0;
            var result = string.Empty;
            //先加入填空值
            for (int i = 0; i < Texts.Length; i++)
            {
                result += Texts[i].Text + ",";
            }

            for (var i = 0; i < Radios.Length; i++)
            {
                if (!Radios[i].Checked) continue;
                result += string.Format("{0},", (char)('A' + i));
                score = Convert.ToInt32(Radios[i].Tag ?? 0);
                break;
            }
            return new M_QuestionnaireResultDetail
            {
                QuestionResult = result,
                QuestionScore = score,
                QuestionType = Type,
                QuestionCode = Code,
                PQuestionWeightScore = score * Weight
            };
        }
        //---by hp end---

        private M_QuestionnaireResultDetail RadioToDetail()
        {
            if (Radios == null || !Radios.Any()) return null;
            var score = 0;
            var result = string.Empty;
            for (var i = 0; i < Radios.Length; i++)
            {
                if (!Radios[i].Checked) continue;
                result = string.Format("{0},", (char)('A' + i));
                score = Convert.ToInt32(Radios[i].Tag ?? 0);
                break;
            }
            return new M_QuestionnaireResultDetail
            {
                QuestionResult = result,
                QuestionScore = score,
                QuestionType = Type,
                QuestionCode = Code,
                PQuestionWeightScore = score * Weight
            };
        }

        private M_QuestionnaireResultDetail CheckBoxToDetail()
        {
            if (CheckBoxs == null || !CheckBoxs.Any()) return null;
            var score = 0;
            var result = new List<char>();
            for (var i = 0; i < CheckBoxs.Length; i++)
            {
                if (!CheckBoxs[i].Checked) continue;
                result.Add((char)('A' + i));
                score += Convert.ToInt32(CheckBoxs[i].Tag ?? 0);
            }
            return new M_QuestionnaireResultDetail
            {
                //QuestionResult = string.Join(",", result) + ",",
                QuestionResult = !result.Any() ? string.Join(",", result) : string.Join(",", result) + ",",
                QuestionScore = score,
                QuestionType = Type,
                QuestionCode = Code,
                PQuestionWeightScore = score * Weight
            };
        }

        private M_QuestionnaireResultDetail TextToDetail()
        {
            if (Text == null) return null;
            return new M_QuestionnaireResultDetail
            {
                QuestionResult = Text.Text.Trim(),
                QuestionCode = Code,
                QuestionType = Type
            };
        }

        public void Parse(string answer)
        {
            if (string.IsNullOrEmpty(answer) || string.IsNullOrEmpty(answer.Trim())) return;
            switch (Type)
            {
                case 1:
                    ParseRadio(answer);
                    return;
                case 2:
                    ParseCheckBox(answer);
                    return;
                case 3:
                    Text.Text = answer;
                    return;
                //---by hp---
                case 4:
                    ParseTextBoxAndRadio(answer);
                    return;
                //---by hp end---
            }
        }

        //---by hp---
        private void ParseTextBoxAndRadio(string answer)
        {
            string[] strs= answer.Split(',');
            int flag = 0;
            //List<TextBox> textBoxs=new List<TextBox>();
            for (int i = 0; i < strs.Length; i++)
            {
                if (!strs[i].Contains("A") && !strs[i].Contains("B") && !strs[i].Contains("C") && !strs[i].Contains("D") &&
                    !strs[i].Contains("E") && !strs[i].Contains("F") && !strs[i].Contains("G") && !strs[i].Contains("H") &&
                    !strs[i].Contains("I") && !strs[i].Contains("J") && !strs[i].Contains("K") && !strs[i].Contains("L"))
                {
                    //textBoxs.Add(new TextBox() {Text = strs[i]});
                    if (Texts.Length > i)
                    {
                        Texts[i].Text = strs[i];
                    }
                }
                else
                {
                    flag = i;
                }
            }
            //Texts = textBoxs.ToArray();

            var index = char.Parse(strs[flag]) - 'A';
            if (index < 0) return;
            Radios[index].Checked = true;
        }
        //---by hp end---

        private void ParseRadio(string answer)
        {
            var chars = answer.Split(',')[0];
            var index = chars[0] - 'A';
            if (index < 0) return;
            Radios[index].Checked = true;
        }

        private void ParseCheckBox(string answer)
        {
            if (string.IsNullOrEmpty(answer)) return;
            var index = answer.Substring(0,answer.Length-1).Split(',').Select(p => p.First() - 'A').Where(p => p >= 0);
            foreach (var option in index)
            {
                CheckBoxs[option].Checked = true;
            }
        }

        public bool IsUncheckedOrEmpty()
        {
            switch (Type)
            {
                case 1:
                    return Radios.Any(p => p.Checked==true);
                case 2:
                    return CheckBoxs.Any(p => p.Checked);
                case 3:
                    return string.IsNullOrEmpty(Text.Text);
                //---by hp---
                case 4:
                    return Texts.All(p => !string.IsNullOrEmpty(p.Text)) && Radios.Any(p => p.Checked);
                //---by hp end---
                default:
                    return false;
            }
        }
    }
}
