using System.Runtime.Serialization;

namespace XYS.Remp.Screening.Model
{
    /// <summary>
    /// 测试Model
    /// </summary>
    [DataContract]
    public class M_Test
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
