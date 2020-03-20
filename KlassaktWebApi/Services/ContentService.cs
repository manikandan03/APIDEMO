using KlassaktWebApi.UnitOfWork;
using KlassaktWebApi.DataAccess;
using KlassaktWebApi.Repository;
using System.Collections.Generic;
using AutoMapper;
using KlassaktWebApi.Models;

namespace KlassaktWebApi.Services
{
    public class ContentService : IContentService
    {

        protected readonly IUnitOfWorkProvider _unitOfWorkProvider;
        protected readonly IMapper _mapper;

        public ContentService(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
            _mapper = mapper;

        }

        public IEnumerable<MasterCourseDto> GetCourses()
        {
            var courses = _unitOfWorkProvider.MasterfCourseRepository.GetAll();
            var courseModel = _mapper.Map<IEnumerable<Master_Course>, List<MasterCourseDto>>(courses);
            return courseModel;
        }

        public MasterCourseDto GetCourseById(int courseId)
        {
            var course = _unitOfWorkProvider.MasterfCourseRepository.GetById(courseId);
            if (course != null)
            {
                var courseModel = _mapper.Map<Master_Course, MasterCourseDto>(course);
                return courseModel;
            }
            return null;
        }

        public bool CreateCourse(MasterCourseDto masterCourseDto)
        {
            var success = false;
            try
            {
                _unitOfWorkProvider.UnitOfWork.CreateTransaction();
                var course = new Master_Course
                {
                    CourseName = masterCourseDto.CourseName,
                    Active = true
                };
                _unitOfWorkProvider.MasterfCourseRepository.Insert(course);
                _unitOfWorkProvider.UnitOfWork.Save();
                _unitOfWorkProvider.UnitOfWork.Commit();
                success = true;
            }
            catch (System.Exception)
            {

                _unitOfWorkProvider.UnitOfWork.Rollback();
            }
            return success;
        }
        public bool UpdateCourse(MasterCourseDto masterCourseDto)
        {
            var success = false;
            try
            {
                _unitOfWorkProvider.UnitOfWork.CreateTransaction();
                var course = _unitOfWorkProvider.MasterfCourseRepository.GetById(masterCourseDto.PK_ID);
                if(course!=null)
                {
                    course.CourseName = masterCourseDto.CourseName;
                    course.Active = masterCourseDto.Active;
                    _unitOfWorkProvider.MasterfCourseRepository.Update(course);
                    _unitOfWorkProvider.UnitOfWork.Save();
                    _unitOfWorkProvider.UnitOfWork.Commit();
                    success = true;
                }
            }
            catch (System.Exception)
            {

                _unitOfWorkProvider.UnitOfWork.Rollback();
            }
            return success;
        }
        public bool DeleteCourse(int id)
        {
            var success = false;
            try
            {
                _unitOfWorkProvider.UnitOfWork.CreateTransaction();
                var course = _unitOfWorkProvider.MasterfCourseRepository.GetById(id);
                if (course != null)
                {
                    course.Active = false;
                    _unitOfWorkProvider.MasterfCourseRepository.Update(course);
                    _unitOfWorkProvider.UnitOfWork.Save();
                    _unitOfWorkProvider.UnitOfWork.Commit();
                    success= true;
                }
            }
            catch (System.Exception)
            {

                _unitOfWorkProvider.UnitOfWork.Rollback();
            }
            return success;

        }
    }
}