using MyMechanic.Domain;
using System;
using System.Linq;

namespace MyMechanic.DataNHibernate.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
       
    }

    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        
    }
}
