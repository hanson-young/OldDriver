using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XYS.Remp.Screening.Model
{
      [DataContract]
    public class M_Questionnaire
    {
        /// <summary>
        ///问卷ID
        /// </summary>
        [DataMember]
        public int QuestionnaireId
        {
            set;
            get;
        }
        /// <summary>
        /// 问卷名称
        /// </summary>
        [DataMember]
        public string QuestionnaireName
        {
            set;
            get;
        }
        /// <summary>
        /// 问卷编码
        /// </summary>
       [DataMember]
        public string QuestionnaireCode
        {
            set;
            get;
        }
        /// <summary>
        /// 医院编码
        /// </summary>
        [DataMember]
        public int QuestionnaireOrgCode
        {
            set;
            get;
        }
    }
}
