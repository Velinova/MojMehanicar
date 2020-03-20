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
    public interface IVehicleService
    {
        VehicleViewModel GetById(Guid id);
        Guid Create(CreateVehicleViewModel model);
        void Update(UpdateVehicleViewModel model);
        void Delete(Guid id);
        IList<VehicleGridViewModel> GetAll();


    }

    public class VehicleService : IVehicleService
    {
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUserRepository userRepository, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public void Delete(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var vehicle = _vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.VehicleException.NOT_FOUND);
            }

            _vehicleRepository.Delete(vehicle);
            _unitOfWork.Commit();
        }

        public IList<VehicleGridViewModel> GetAll()
        {
            _unitOfWork.BeginTransaction();

            var allVehicles = _vehicleRepository.GetAll();
            var allVehiclesViewModel = allVehicles.Select(x => x.MapToGridViewModel()).ToList();

            _unitOfWork.Commit();

            return allVehiclesViewModel;
        }

        public Guid Create(CreateVehicleViewModel model)
        {
            _unitOfWork.BeginTransaction();

            var owner = _userRepository.GetById(model.Owner.Id);

            if(owner == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }
            
            var vehicle = new Vehicle(model.Type, model.Model, model.License, owner) ;
            _vehicleRepository.Add(vehicle);
            _unitOfWork.Commit();
            return vehicle.Id;

        }
        public VehicleViewModel GetById(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var vehicle = _vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.VehicleException.NOT_FOUND); ;
            }

            var vehicleViewModel = vehicle.MapToViewModel();
            _unitOfWork.Commit();

            return vehicleViewModel;
        }

        public void Update(UpdateVehicleViewModel model)
        {
            _unitOfWork.BeginTransaction();

            var vehicle = _vehicleRepository.GetById(model.Id);

            if (vehicle == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.VehicleException.NOT_FOUND);
            }

            vehicle.Type = model.Type;
            vehicle.Model = model.Model;
            vehicle.License = model.License;

            _vehicleRepository.Update(vehicle);
            _unitOfWork.Commit();
        }

    }
}
