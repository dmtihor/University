using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Db.Entity
{
    public sealed class Seminar
    {
        public int SeminarId { get; set; }
        public string SeminarName { get; set; }
        public DateTime SeminarTime { get; set; }
        
        public ICollection<Lecturer> Lecturers { get; set; }

        public Seminar()
        {
            Lecturers = new List<Lecturer>();
        }
    }
}