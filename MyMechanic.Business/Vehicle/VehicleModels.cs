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

    public class VehicleViewModelValidator : AbstractValidator<VehicleViewModel>
    {
        public VehicleViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Owner)
                .NotEmpty().WithMessage("Owner is required");
            RuleFor(x => x.Type).
                NotEmpty().WithMessage("Type is required")
                .IsInEnum();
            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required")
                .MaximumLength(50);
            RuleFor(x => x.License)
                .NotEmpty().WithMessage("License is required")
                .MaximumLength(50);
        }
    }
    public class UpdateVehicleViewModelValidator : AbstractValidator<UpdateVehicleViewModel>
    {
        public UpdateVehicleViewModelValidator()
        {
            RuleFor(x => x.License)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Model).
                NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Type)
                .NotEmpty()
                .IsInEnum();
            RuleFor(x => x.Id)
                .NotEmpty();

        }
    }
    public class CreateVehicleViewModelValidator : AbstractValidator<CreateVehicleViewModel>
    {
        public CreateVehicleViewModelValidator()
        {
            RuleFor(x => x.License)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Model).
                NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Type)
                .NotEmpty()
                .IsInEnum();
        }
    }

    #endregion
    #region ViewModels
    public class VehicleViewModel {
        public Guid Id { get; set; }
        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public string License { get; set; }
        public UserViewModel Owner { get; set; }
    }
    public class VehicleGridViewModel
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string License { get; set; }
        public string OwnerName { get; set; }
        public string Type { get; set; }
        public int InspectionsCount { get; set; }
    }
    [Validator(typeof(UpdateVehicleViewModelValidator))]
    public class UpdateVehicleViewModel
    {
        public Guid Id { get; set; }
        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public string License { get; set; }
    }
    [Validator(typeof(CreateVehicleViewModelValidator))]

    public class CreateVehicleViewModel{
        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public string License { get; set; }
        public UserViewModel Owner { get; set; }
    }
    #endregion
}
