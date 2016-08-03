using System.Collections.Generic;
using System.ServiceModel;
using University.Wcf.Entity;

namespace University.Wcf.Contracts
{

    [ServiceContract]
    public interface ISeminarService
    {
        [OperationContract]
        List<SeminarWcf> GetAllSeminars();

        [OperationContract]
        void AddSeminar(SeminarWcf seminar);

        [OperationContract]
        SeminarWcf GetSeminarById(int id);

        [OperationContract]
        void RemoveSeminar(int id);

        [OperationContract]
        void UpdateSeminar(SeminarWcf seminar);

        [OperationContract]
        List<LecturerWcf> GetLecturers(int id);
    }
}
