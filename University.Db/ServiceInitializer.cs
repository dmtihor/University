using System;
using System.Data.Entity;
using University.Db.Entity;

namespace University.Db
{
    public class ServiceInitializer : DropCreateDatabaseIfModelChanges<ServiceContext>
    {
        protected override void Seed(ServiceContext context)
        {
            var testLecturer1 = new Lecturer() { LecturerName = "John", LecturerAddress = "IF", LecturerAge = 35 };
            var testLecturer2 = new Lecturer() { LecturerName = "Debra", LecturerAddress = "Lviv", LecturerAge = 32 };
            var testLecturer3 = new Lecturer() { LecturerName = "Michael", LecturerAddress = "Ternopil", LecturerAge = 25 };

            var testSeminar1 = new Seminar() { SeminarName = "Math", SeminarTime = new DateTime(2016, 8, 20, 10, 30, 00) };
            var testSeminar2 = new Seminar() { SeminarName = "Programming", SeminarTime = new DateTime(2016, 8, 21, 10, 30, 00) };
            var testSeminar3 = new Seminar() { SeminarName = "History", SeminarTime = new DateTime(2016, 8, 24, 12, 30, 00) };

            testSeminar1.Lecturers.Add(testLecturer1);
            testSeminar1.Lecturers.Add(testLecturer2);

            testSeminar2.Lecturers.Add(testLecturer2);

            testSeminar3.Lecturers.Add(testLecturer2);
            testSeminar3.Lecturers.Add(testLecturer3);

            context.Lecturers.AddRange(new[] { testLecturer1, testLecturer2, testLecturer3 });
            context.Seminars.AddRange(new[] { testSeminar1, testSeminar2, testSeminar3 });


            context.SaveChanges();

            base.Seed(context);
        }
    }
}
