

using System;

namespace KlassaktWebApi.Models
{
    public class MasterCourseDto
    {
        public int PK_ID { get; set; }
        public string CourseName { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}