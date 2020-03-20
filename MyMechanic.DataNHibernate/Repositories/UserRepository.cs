using MyMechanic.Domain;
using System;
using System.Linq;

namespace MyMechanic.DataNHibernate.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool emailTaken(User user);
        bool userNameTaken(User user);
        Guid signIn(User user);
        IQueryable<User> getAllAdmins();
        IQueryable<User> getAllUsers();
        IQueryable<User> getAll();
        IQueryable<Vehicle> getAllVehicles();
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public bool emailTaken(User user)
        {
            bool emailTaken = Session.Query<User>()
                    .Any(x => x.Email == user.Email);

            return emailTaken;
        }

        public IQueryable<User> getAll()
        {
            return Session.Query<User>();
        }

        public IQueryable<User> getAllAdmins()
        {
            return Session.Query<User>().Where(x => x.Role == UserRole.USER);
        }

        public IQueryable<User> getAllUsers()
        {
            return Session.Query<User>().Where(x => x.Role == UserRole.ADMIN);
        }

        public IQueryable<Vehicle> getAllVehicles()
        {
            throw new NotImplementedException();
        }

        public Guid signIn(User user)
        {
            var signedIn = Session.Query<User>().Single(x => x.Email == user.Email && x.Password == user.Password);
            return signedIn.Id;
        }

        public bool userNameTaken(User user)
        {
            bool userNameTaken = Session.Query<User>()
                .Any(x => x.UserName == user.UserName);

            return userNameTaken;
        }
    }
}
