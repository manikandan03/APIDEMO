
using KlassaktWebApi.DataAccess;
using KlassaktWebApi.Models;
using System.Collections.Generic;

namespace KlassaktWebApi.Services
{
    public interface IContentService
    {
        IEnumerable<MasterCourseDto> GetCourses();
        MasterCourseDto GetCourseById(int courseId);
        bool CreateCourse(MasterCourseDto masterCourseDto);
        bool UpdateCourse(MasterCourseDto masterCourseDto);
        bool DeleteCourse(int id);
    }
}
