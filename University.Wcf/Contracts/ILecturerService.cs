using System.Collections.Generic;
using System.ServiceModel;
using University.Wcf.Entity;

namespace University.Wcf.Contracts
{
    [ServiceContract]
    public interface ILecturerService
    {
        [OperationContract]
        List<LecturerWcf> GetAllLecturers();

        [OperationContract]
        void AddLecturer(LecturerWcf lecturer);

        [OperationContract]
        LecturerWcf GetLecturerById(int id);

        [OperationContract]
        void RemoveLecturer(int id);

        [OperationContract]
        void UpdateLecturer(LecturerWcf lecturer);

        [OperationContract]
        List<SeminarWcf> GetSeminars(int id);

    }
}
