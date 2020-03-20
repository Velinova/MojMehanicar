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
    public interface IMechanicService
    {
        MechanicViewModel GetById(Guid id);
        void Update(UpdateMechanicViewModel model);
        void Delete(Guid id);
        Guid RegisterMechanic(RegisterMechanicViewModel model);
        Guid SignInMechanic(SignInMechanicViewModel model);
        IList<MechanicGridViewModel> GetAll();
        IList<ListMechanicGridViewModel> GetAllList();
        IList<TechnicalInspectionViewModel> GetInspections(Guid id);
        float GetAverage(Guid id);
    }

    public class MechanicService : IMechanicService
    {
        private readonly IMechanicRepository _mechanicRepository;
        private readonly ITechnicalInspectionRepository _technicalInspectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MechanicService(IMechanicRepository mechanicRepository, ITechnicalInspectionRepository technicalInspectionRepository,  IUnitOfWork unitOfWork)
        {
            _mechanicRepository = mechanicRepository;
            _technicalInspectionRepository = technicalInspectionRepository;
            _unitOfWork = unitOfWork;
        }

        public void Delete(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var mechanic = _mechanicRepository.GetById(id);

            if (mechanic == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.NOT_FOUND);
            }

            _mechanicRepository.Delete(mechanic);
            _unitOfWork.Commit();
        }

        public IList<MechanicGridViewModel> GetAll()
        {
            _unitOfWork.BeginTransaction();

            var allMechanics = _mechanicRepository.GetAll();
            var allMechanicsViewModel = allMechanics.Select(x => x.MapToGridViewModel()).ToList();

            _unitOfWork.Commit();

            return allMechanicsViewModel;
        }

        public IList<ListMechanicGridViewModel> GetAllList()
        {
            _unitOfWork.BeginTransaction();

            var allMechanics = _mechanicRepository.GetAll();
            var allMechanicsViewModel = allMechanics.Select(x => x.MapToListViewModel()).ToList();

            _unitOfWork.Commit();

            return allMechanicsViewModel;
        }

        public float GetAverage(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var mechanic = _mechanicRepository.GetById(id);

            if(mechanic == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.NOT_FOUND);
            }

            var inspections = GetInspections(id);
            var count = 0;
            var sum = 0;
            float average = 0f;
            for(int i=0; i< inspections.Count; i++)
            {
                sum += inspections[i].Rating;
                if (inspections[i].Rating != 0)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                average = sum / count;
            }
            else
            {
                average = 0;
            }
            _unitOfWork.Commit();
            return average;

        }

        public MechanicViewModel GetById(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var mechanic = _mechanicRepository.GetById(id);

            if (mechanic == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.NOT_FOUND);
            }

            var mechanicViewModel = mechanic.MapToViewModel();
            _unitOfWork.Commit();

            return mechanicViewModel;
        }

        public IList<TechnicalInspectionViewModel> GetInspections(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var mechanic = _mechanicRepository.GetById(id);

            if(mechanic == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.NOT_FOUND);
            }

            var inspections = _technicalInspectionRepository.GetAll().Where(x => x.Mechanic.Id == mechanic.Id);
            var inspectionViewModel = inspections.Select(x => x.MapToViewModel()).ToList();

            _unitOfWork.Commit();
            return inspectionViewModel;
        }

        public void Update(UpdateMechanicViewModel model)
        {
            _unitOfWork.BeginTransaction();

            var mechanic = _mechanicRepository.GetById(model.Id);

            if (mechanic == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.NOT_FOUND);
            }

            mechanic.UserName = model.UserName;
            mechanic.Email = model.Email;
            mechanic.Password = model.Password;
            mechanic.CompanyName = model.CompanyName;
            mechanic.City = model.City;
            mechanic.Country = model.Country;
            mechanic.PostalCode = model.PostalCode;
            mechanic.Address = model.Address;

            _mechanicRepository.Update(mechanic);
            _unitOfWork.Commit();
        }

        Guid IMechanicService.RegisterMechanic(RegisterMechanicViewModel model)
        {
            _unitOfWork.BeginTransaction();
            
            var mechanic = new Mechanic(model.UserName, model.Password, model.Email, model.CompanyName, model.City, model.Country, model.PostalCode, model.Address);

            if (_mechanicRepository.emailTaken(mechanic))
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.EMAIL_TAKEN);
            }
            var isTaken = _mechanicRepository.userNameTaken(mechanic);
            if (isTaken)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.USERNAME_TAKEN);
            }

            _mechanicRepository.Add(mechanic);
            _unitOfWork.Commit();

            return mechanic.Id;
        }

        Guid IMechanicService.SignInMechanic(SignInMechanicViewModel model)
        {
            _unitOfWork.BeginTransaction();

            var mechanic = _mechanicRepository.GetAll().Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if (mechanic == null)
            {
                _unitOfWork.Commit();
                throw new Exception(ExceptionMessages.MechanicException.NOT_FOUND);
            }

            var mechanicId = _mechanicRepository.signIn(mechanic);

            _unitOfWork.Commit();
            return mechanicId;
        }
    }
}
