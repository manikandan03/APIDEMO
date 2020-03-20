using KlassaktWebApi.Models;
using KlassaktWebApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace KlassaktWebApi.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        private readonly IContentService _contentService;

        public HomeController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [Route("GetAllCourses")]
        public List<MasterCourseDto> GetCourses()
         {
            var courses = _contentService.GetCourses();
            var courseEntities = courses as List<MasterCourseDto> ?? courses.ToList();
            return courseEntities;
        }

        [Route("GetCourseByID")]
        public MasterCourseDto GetCourseByID(int id)
        {
            if (id > 0)
            {
                var product = _contentService.GetCourseById(id);
                if (product != null)
                    return product;

            }
            return new MasterCourseDto();
        }

        [Route("Create")]
        public bool Create([FromBody] MasterCourseDto masterCourse)
        {
           return _contentService.CreateCourse(masterCourse);
        }

        [Route("Update")]
        public bool Update([FromBody] MasterCourseDto masterCourse)
        {
          return  _contentService.UpdateCourse(masterCourse);
        }

        [Route("Delete")]
        public bool DeleteCourse(int id)
        {
            if (id > 0)
            {
              return _contentService.DeleteCourse(id);
            }
            return false;
        }

    }
}
