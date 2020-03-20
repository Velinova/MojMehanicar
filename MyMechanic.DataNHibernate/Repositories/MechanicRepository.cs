using MyMechanic.Domain;
using System;
using System.Linq;

namespace MyMechanic.DataNHibernate.Repositories
{
    public interface IMechanicRepository : IRepository<Mechanic>
    {
        int GetCountTechnicalInspections(Mechanic mechanic);
        bool emailTaken(Mechanic mechanic);
        bool userNameTaken(Mechanic mechanic);
        Guid signIn(Mechanic mechanic);

    }

    public class MechanicRepository : RepositoryBase<Mechanic>, IMechanicRepository
    {
        public MechanicRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public int GetCountTechnicalInspections(Mechanic mechanic)
        {
            return Session.Query<TechnicalInspection>().Where(x => x.Mechanic.Id == mechanic.Id).Count();
        }
        public bool emailTaken(Mechanic mechanic)
        {
            bool emailTaken = Session.Query<Mechanic>()
                    .Any(x => x.Email == mechanic.Email);

            return emailTaken;
        }
        public Guid signIn(Mechanic mechanic)
        {
            var signedIn = Session.Query<Mechanic>().Single(x => x.Email == mechanic.Email && x.Password == mechanic.Password);
            return signedIn.Id;
        }

        public bool userNameTaken(Mechanic mechanic)
        {
            bool userNameTaken = Session.Query<Mechanic>()
                .Any(x => x.UserName == mechanic.UserName);

            return userNameTaken;
        }
    }
}
