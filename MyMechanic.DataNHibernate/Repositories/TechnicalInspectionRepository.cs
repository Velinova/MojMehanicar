using MyMechanic.Domain;
using System;
using System.Linq;

namespace MyMechanic.DataNHibernate.Repositories
{
    public interface ITechnicalInspectionRepository : IRepository<TechnicalInspection>
    {
        //void ChangeStatus(Guid inspectionId,int newStatus);
    }

    public class TechnicalInspectionRepository : RepositoryBase<TechnicalInspection>, ITechnicalInspectionRepository
    {
        public TechnicalInspectionRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        //public void ChangeStatus(Guid inspectionId, int newStatus)
        //{
        //    var inspection  = Session.Query<TechnicalInspection>().
        //}
    }
}
