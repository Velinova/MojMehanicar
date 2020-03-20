using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using MyMechanic.Domain;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;

namespace MyMechanic.Business.Models
{
    #region Validators

    public class TechnicalInspectionViewModelValidator : AbstractValidator<TechnicalInspectionViewModel>
    {
        public TechnicalInspectionViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Mechanic)
                .NotEmpty().WithMessage("Mechanic is required");
            RuleFor(x => x.Vehicle).
                NotEmpty().WithMessage("Vehicle is required");
            RuleFor(x => x.User).
                NotEmpty().WithMessage("User is required");
            RuleFor(x => x.UserNote)
                .NotEmpty().WithMessage("User note is required")
                .MaximumLength(300);
            RuleFor(x => x.MechanicNote)
                .NotEmpty().WithMessage("Mechanic note is required")
                .MaximumLength(500);
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Statusis required")
                .IsInEnum();
            RuleFor(x => x.Rating)
                .NotEmpty()
                .InclusiveBetween(1, 5);
        }
    }
    public class UpdateTechnicalInspectionViewModelValidator : AbstractValidator<UpdateTechnicalInspectionViewModel>
    {
        public UpdateTechnicalInspectionViewModelValidator()
        {
            RuleFor(x => x.Mechanic)
                .NotEmpty();
            RuleFor(x => x.Vehicle).
                NotEmpty();
            RuleFor(x => x.UserNote)
                .NotEmpty()
                .MaximumLength(300);
            RuleFor(x => x.MechanicNote)
                .NotEmpty()
                .MaximumLength(500);
            RuleFor(x => x.Rating)
                .NotEmpty()
                .InclusiveBetween(1,5);
            RuleFor(x => x.Status)
                .NotEmpty()
                .IsInEnum();

        }
    }

    #endregion
    #region ViewModels
    public class TechnicalInspectionViewModel {
        public Guid Id { get; set; }
        public MechanicViewModel Mechanic { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public UserViewModel User { get; set; }
        public string UserNote { get; set; }
        public string MechanicNote { get; set; }
        public InspectionStatus Status { get; set; }
        public int Rating { get; set; }
    }
    public class TechnicalInspectionGridViewModel
    {
        public Guid Id { get; set; }
        public string VehicleLicense { get; set; }
        public string MechanicName { get; set; }
        public string VehicleOwner { get; set; }
        public string Status { get; set; }
        public int Rating { get; set; }
    }
    public class UpdateTechnicalInspectionViewModel
    {
        public Guid Id { get; set; }
        public MechanicViewModel Mechanic { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public string UserNote { get; set; }
        public string MechanicNote { get; set; }
        public InspectionStatus Status { get; set; }
        public int Rating { get; set; }
    }
    public class CreateTechnicalInspectionViewModel{
        
        public MechanicViewModel Mechanic { get; set; }
        public UserViewModel User { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public string UserNote { get; set; }
    }
    #endregion
}
