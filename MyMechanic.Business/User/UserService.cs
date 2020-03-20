using MyMechanic.Business.Mappers;
using MyMechanic.Business.Models;
using MyMechanic.DataNHibernate;
using MyMechanic.DataNHibernate.Repositories;
using MyMechanic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMechanic.Business.Services
{
    public interface IUserService
    {
        UserViewModel GetById(Guid id);
        void Update(UpdateUserViewModel model);
        void Delete(Guid id);
        void ChangeRole(Guid id);
        UserRole GetRole(Guid id);
        Guid RegisterUser(RegisterUserViewModel model);
        Guid SignInUser(SignInUserViewModel model);
        IList<UserGridViewModel> GetAllAdmins();
        IList<UserGridViewModel> GetAllUsers();
        IList<UserGridViewModel> GetAll();
        IList<VehicleViewModel> GetVehicles(Guid id);

    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IVehicleRepository  vehicleRepository,  IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public void ChangeRole(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(id);

            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            if (user.Role == UserRole.ADMIN)
            {
                user.Role = UserRole.USER;
            }
            else
            {
                user.Role = UserRole.ADMIN;
            }

            _userRepository.Update(user);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(id);

            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            _userRepository.Delete(user);
            _unitOfWork.Commit();
        }

        public IList<UserGridViewModel> GetAll()
        {
            _unitOfWork.BeginTransaction();

            var allUsers = _userRepository.getAll();
            var allUsersViewModel = allUsers.Select(x => x.MapToGridViewModel()).ToList();

            _unitOfWork.Commit();

            return allUsersViewModel;
        }

        public IList<UserGridViewModel> GetAllAdmins()
        {
            _unitOfWork.BeginTransaction();

            var admins = _userRepository.getAllAdmins();
            var adminsViewModel = admins.Select(x => x.MapToGridViewModel()).ToList();

            _unitOfWork.Commit();

            return adminsViewModel;
        }

        public IList<UserGridViewModel> GetAllUsers()
        {
            _unitOfWork.BeginTransaction();

            var users = _userRepository.getAllUsers();
            var usersViewModel = users.Select(x => x.MapToGridViewModel()).ToList();

            _unitOfWork.Commit();

            return usersViewModel;
        }

        public UserViewModel GetById(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(id);

            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            var userViewModel = user.MapToViewModel();
            _unitOfWork.Commit();

            return userViewModel;
        }

        public UserRole GetRole(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(id);
            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }
            _unitOfWork.Commit();
            return user.Role;
        }

        public IList<VehicleViewModel> GetVehicles(Guid id)
        {
            _unitOfWork.BeginTransaction();
            var user = _userRepository.GetById(id);
            if(user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            var vehicles = _vehicleRepository.GetAll().Where(x => x.Owner == user);
            var model = vehicles.Select(x => x.MapToViewModel()).ToList();

            _unitOfWork.Commit();
            return model;

        }

        public void Update(UpdateUserViewModel model)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(model.Id);

            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.City = model.City;
            user.Country = model.Country;
            user.PostalCode = model.PostalCode;
            user.Address = model.Address;
            user.Role = model.Role;

            _userRepository.Update(user);
            _unitOfWork.Commit();
        }

        Guid IUserService.RegisterUser(RegisterUserViewModel model)
        {
            _unitOfWork.BeginTransaction();
            
            var user = new User(model.UserName, model.Password, model.Email, model.Name, model.Surname, model.City, model.Country, model.PostalCode, model.Address);

            if (_userRepository.emailTaken(user))
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.EMAIL_TAKEN);
            }
            var isTaken = _userRepository.userNameTaken(user);
            if (isTaken)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.USERNAME_TAKEN);
            }

            _userRepository.Add(user);
            _unitOfWork.Commit();

            return user.Id;
        }

        Guid IUserService.SignInUser(SignInUserViewModel model)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetAll().Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            var userId = _userRepository.signIn(user);

            _unitOfWork.Commit();
            return userId;
        }
    }
}
