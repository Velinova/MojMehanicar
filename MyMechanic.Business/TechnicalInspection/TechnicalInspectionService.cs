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
    public interface ITechnicalInspectionService
    {
        TechnicalInspectionViewModel GetById(Guid id);
        Guid Create(CreateTechnicalInspectionViewModel model);
        void Update(UpdateTechnicalInspectionViewModel model);
        void Delete(Guid id);
        IList<TechnicalInspectionGridViewModel> GetAll();
        IList<TechnicalInspectionViewModel> GetPendingInspections(Guid id);
        IList<TechnicalInspectionViewModel> GetInProgressInspections(Guid id);
        IList<TechnicalInspectionViewModel> GetDoneInspections(Guid id);
       

    }

    public class TechnicalInspectionService : ITechnicalInspectionService
    {
        private readonly IMechanicRepository _mechanicRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITechnicalInspectionRepository _technicalInspectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TechnicalInspectionService(IMechanicRepository mechanicRepository, IUserRepository userRepository, IVehicleRepository vehicleRepository, ITechnicalInspectionRepository technicalInspectionRepository,  IUnitOfWork unitOfWork)
        {
            _mechanicRepository = mechanicRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _technicalInspectionRepository = technicalInspectionRepository;
            _unitOfWork = unitOfWork;
        }



        public void Delete(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var inspection = _technicalInspectionRepository.GetById(id);

            if (inspection == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.TechnicalInspectionException.NOT_FOUND);
            }

            _technicalInspectionRepository.Delete(inspection);
            _unitOfWork.Commit();
        }

        public IList<TechnicalInspectionGridViewModel> GetAll()
        {
            _unitOfWork.BeginTransaction();

            var allInspections = _technicalInspectionRepository.GetAll();
            var allInspectionsViewModel = allInspections.Select(x => x.MapToGridViewModel()).ToList();

            _unitOfWork.Commit();

            return allInspectionsViewModel;
        }

        public Guid Create(CreateTechnicalInspectionViewModel model)
        {
            _unitOfWork.BeginTransaction();

            var mechanic = _mechanicRepository.GetById(model.Mechanic.Id);
            
            if(mechanic == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.NOT_FOUND);
            }

            var vehicle = _vehicleRepository.GetById(model.Vehicle.Id);

            if(vehicle == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.VehicleException.NOT_FOUND);
            }
            var user = _userRepository.GetById(model.User.Id);

            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            var inspection = new TechnicalInspection(mechanic, vehicle,user,  model.UserNote);
            _technicalInspectionRepository.Add(inspection);

            _unitOfWork.Commit();
            return inspection.Id;

        }
        public TechnicalInspectionViewModel GetById(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var inspection = _technicalInspectionRepository.GetById(id);

            if (inspection == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.TechnicalInspectionException.NOT_FOUND);
            }

            var inspectionViewModel = inspection.MapToViewModel();
            _unitOfWork.Commit();

            return inspectionViewModel;
        }
        
        public void Update(UpdateTechnicalInspectionViewModel model)
        {
            _unitOfWork.BeginTransaction();

            var inspection = _technicalInspectionRepository.GetById(model.Id);

            if (inspection == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.TechnicalInspectionException.NOT_FOUND);
            }

            inspection.UserNote = model.UserNote;
            if (model.Status == InspectionStatus.DONE)
            {
                inspection.MechanicNote = model.MechanicNote;
            }
            inspection.Status = model.Status;
            inspection.Rating = model.Rating;
      
            _technicalInspectionRepository.Update(inspection);
            _unitOfWork.Commit();
        }

        public IList<TechnicalInspectionViewModel> GetPendingInspections(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(id);

            if(user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            var pending = _technicalInspectionRepository.GetAll().Where(x => x.Status == InspectionStatus.PENDING);
            var pendingViewModel = pending.Select(x => x.MapToViewModel()).ToList();

            _unitOfWork.Commit();
            return pendingViewModel;
        }

        public IList<TechnicalInspectionViewModel> GetInProgressInspections(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(id);

            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            var pending = _technicalInspectionRepository.GetAll().Where(x => x.Status == InspectionStatus.IN_PROGRESS);
            var pendingViewModel = pending.Select(x => x.MapToViewModel()).ToList();

            _unitOfWork.Commit();
            return pendingViewModel;
        }

        public IList<TechnicalInspectionViewModel> GetDoneInspections(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(id);

            if (user == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.UserException.NOT_FOUND);
            }

            var pending = _technicalInspectionRepository.GetAll().Where(x => x.Status == InspectionStatus.DONE);
            var pendingViewModel = pending.Select(x => x.MapToViewModel()).ToList();

            _unitOfWork.Commit();
            return pendingViewModel;
        }
    }
}
