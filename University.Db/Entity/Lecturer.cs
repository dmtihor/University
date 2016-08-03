using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Db.Entity
{
    public sealed class Lecturer
    {
        public int LecturerId { get; set; }
        [Required]
        public string LecturerName { get; set; }
        public int LecturerAge { get; set; }
        public string LecturerAddress { get; set; }

        public ICollection<Seminar> Seminars { get; set; }

        public Lecturer()
        {
            Seminars = new List<Seminar>();
        }
    }
}
