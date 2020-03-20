using KlassaktWebApi.DataAccess;
using KlassaktWebApi.Repository;

namespace KlassaktWebApi.UnitOfWork
{
    public interface IUnitOfWorkProvider
    {
        GenericRepository<Master_Course> MasterfCourseRepository { get; }
        GenericRepository<UnitsOfCourse> UnitsofCourseRepository { get; }
        GenericRepository<SectionsOfUnit> SectionsofUnitsRepository { get; }
        GenericRepository<QAOfSection> QaofSectionsRepository { get; }
        UnitOfWork<LMSContentEntities> UnitOfWork { get; }
    }
}