using System.Runtime.Serialization;

namespace University.Wcf.Entity
{
    [DataContract(IsReference = true)]
    public class LecturerWcf
    {
        [DataMember]
        public int LecturerId { get; set; }
        [DataMember]
        public string LecturerName { get; set; }
        [DataMember]
        public string LecturerAddress { get; set; }
        [DataMember]
        public int LecturerAge { get; set; }
    }
}