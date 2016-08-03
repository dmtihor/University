using AutoMapper;
using University.Db.Entity;
using University.Wcf.Entity;

namespace University.Wcf
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
              {
                  cfg.CreateMap<Lecturer, LecturerWcf>().ReverseMap();
                  cfg.CreateMap<Seminar, SeminarWcf>().ReverseMap();
              });
        }
    }
}