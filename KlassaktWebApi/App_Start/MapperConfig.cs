using AutoMapper;
using KlassaktWebApi.DataAccess;
using KlassaktWebApi.Models;

namespace KlassaktWebApi.App_Start
{
    public static class MapperConfig
    {
        private static MapperConfiguration mapperConfiguration;
        static MapperConfig()
        {
            MapperConfiguration = new MapperConfiguration(
                cfg =>
                {
                    //Create all maps here
                    cfg.CreateMap<Master_Course, MasterCourseDto>();

                });
        }

        public static MapperConfiguration MapperConfiguration { get => mapperConfiguration; set => mapperConfiguration = value; }

    }
}