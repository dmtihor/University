using System;
using System.Runtime.Serialization;

namespace University.Wcf.Entity
{
    [DataContract(IsReference = true)]
    public class SeminarWcf
    {
        [DataMember]
        public int SeminarId { get; set; }
        [DataMember]
        public string SeminarName { get; set; }
        [DataMember]
        public DateTime SeminarTime { get; set; }
    }
}