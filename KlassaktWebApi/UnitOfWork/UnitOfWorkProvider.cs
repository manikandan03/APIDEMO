using KlassaktWebApi.DataAccess;
using KlassaktWebApi.Repository;

namespace KlassaktWebApi.UnitOfWork
{
    public class UnitOfWorkProvider:IUnitOfWorkProvider
    {
        private  UnitOfWork<LMSContentEntities> unitOfWork;
        private  GenericRepository<Master_Course> _masterfCourseRepository;
        private  GenericRepository<UnitsOfCourse> _unitsofCourseRepository;
        private  GenericRepository<SectionsOfUnit> _sectionsofUnitsRepository;
        private  GenericRepository<QAOfSection> _qaofSectionsRepository;
            
        public UnitOfWorkProvider()
        {
            unitOfWork = new UnitOfWork<LMSContentEntities>();
        }

        public GenericRepository<Master_Course> MasterfCourseRepository
        {
            get
            {
                if (this._masterfCourseRepository == null)
                    this._masterfCourseRepository = new GenericRepository<Master_Course>(unitOfWork);
                return _masterfCourseRepository;
            }
        }
        public UnitOfWork<LMSContentEntities> UnitOfWork
        {
            get
            {
                if (this.unitOfWork == null)
                    this.unitOfWork= new UnitOfWork<LMSContentEntities>();
                return unitOfWork;
            }
        }
        public GenericRepository<UnitsOfCourse> UnitsofCourseRepository
        {
            get
            {
                if (this._unitsofCourseRepository == null)
                    this._unitsofCourseRepository = new GenericRepository<UnitsOfCourse>(unitOfWork);
                return _unitsofCourseRepository;
            }
        }
        public GenericRepository<SectionsOfUnit> SectionsofUnitsRepository
        {
            get
            {
                if (this._sectionsofUnitsRepository == null)
                    this._sectionsofUnitsRepository = new GenericRepository<SectionsOfUnit>(unitOfWork);
                return _sectionsofUnitsRepository;
            }
        }
        public GenericRepository<QAOfSection> QaofSectionsRepository
        {
            get
            {
                if (this._qaofSectionsRepository == null)
                    this._qaofSectionsRepository = new GenericRepository<QAOfSection>(unitOfWork);
                return _qaofSectionsRepository;
            }
        }
    }
}