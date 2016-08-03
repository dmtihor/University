using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using University.Db;
using University.Db.Entity;
using University.Wcf.Contracts;
using University.Wcf.Entity;

namespace University.Wcf.Services
{

    public class SeminarService : ISeminarService
    {
        private readonly ServiceContext _db = new ServiceContext();

        public List<SeminarWcf> GetAllSeminars()
        {
            return Mapper.Map<List<SeminarWcf>>(_db.Seminars.ToList());
        }

        public void AddSeminar(SeminarWcf seminar)
        {
            if (seminar.SeminarName == null) return;
            _db.Seminars.Add(Mapper.Map<SeminarWcf, Seminar>(seminar));
            _db.SaveChanges();
        }

        public SeminarWcf GetSeminarById(int id)
        {
            return Mapper.Map<Seminar, SeminarWcf>(_db.Seminars.Find(id));
        }

        public void RemoveSeminar(int id)
        {
            var temp = _db.Seminars.Find(id);
            if (temp == null) return;
            _db.Seminars.Remove(temp);
            _db.SaveChanges();
        }

        public void UpdateSeminar(SeminarWcf seminar)
        {
            var newSeminar = Mapper.Map<SeminarWcf, Seminar>(seminar);
            var oldSeminar = _db.Seminars.FirstOrDefault(x => x.SeminarId == seminar.SeminarId);
            if (oldSeminar == null) return;
            oldSeminar.SeminarName = newSeminar.SeminarName;
            oldSeminar.SeminarTime = newSeminar.SeminarTime;
            _db.SaveChanges();
        }

        public List<LecturerWcf> GetLecturers(int id)
        {
            return _db.Seminars.Include("Lecturers")
                .FirstOrDefault(x => x.SeminarId == id)
                ?.Lecturers
                .Select(Mapper.Map<Lecturer, LecturerWcf>)
                .ToList();
        }
    }
}