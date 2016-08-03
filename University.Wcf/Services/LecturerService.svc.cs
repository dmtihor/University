using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using University.Db;
using University.Db.Entity;
using University.Wcf.Contracts;
using University.Wcf.Entity;

namespace University.Wcf.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly ServiceContext _db = new ServiceContext();

        public List<LecturerWcf> GetAllLecturers()
        {
            return Mapper.Map<List<LecturerWcf>>(_db.Lecturers.ToList());
        }

        public void AddLecturer(LecturerWcf lecturer)
        {
            if (lecturer.LecturerName == null) return;
            _db.Lecturers.Add(Mapper.Map<LecturerWcf, Lecturer>(lecturer));
            _db.SaveChanges();
        }

        public LecturerWcf GetLecturerById(int id)
        {
            return Mapper.Map<Lecturer, LecturerWcf>(_db.Lecturers.Find(id));
        }

        public void RemoveLecturer(int id)
        {
            var temp = _db.Lecturers.Find(id);
            if (temp == null) return;
            _db.Lecturers.Remove(temp);
            _db.SaveChanges();
        }

        public void UpdateLecturer(LecturerWcf lecturer)
        {
            var newLecturer = Mapper.Map<LecturerWcf, Lecturer>(lecturer);
            var oldLecturer = _db.Lecturers.FirstOrDefault(x => x.LecturerId == lecturer.LecturerId);
            if (oldLecturer == null) return;
            oldLecturer.LecturerName = newLecturer.LecturerName;
            oldLecturer.LecturerAddress = newLecturer.LecturerAddress;
            oldLecturer.LecturerAge = newLecturer.LecturerAge;
            _db.SaveChanges();
        }

        public List<SeminarWcf> GetSeminars(int id)
        {
            return _db.Lecturers.Include("Seminars")
                .FirstOrDefault(x => x.LecturerId == id)
                ?.Seminars
                .Select(Mapper.Map<Seminar, SeminarWcf>)
                .ToList();
        }
    }
}
