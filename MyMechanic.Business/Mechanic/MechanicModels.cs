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
    public class RegisterMechanicViewModelValidator : AbstractValidator<RegisterMechanicViewModel>
    {
        
        public RegisterMechanicViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required")
                .MaximumLength(30);
            RuleFor(x => x.Email).
                NotEmpty().WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .MaximumLength(20);
            RuleFor(x => x.ConfirmedPassword)
                .NotEmpty()
                .WithMessage("Password confirmation is required")
                .MinimumLength(6)
                .MaximumLength(20);
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("Company name is required")
                .MaximumLength(30);
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required")
                .MaximumLength(30);
            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("Country is required")
                .MaximumLength(50);
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required")
                .MaximumLength(100);
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .WithMessage("Postal code is required")
                .Matches("[0-9]{4}")
                .WithMessage("Invalid postal code format.");
        }
    }
    
    public class MechanicViewModelValidator : AbstractValidator<MechanicViewModel>
    {
        public MechanicViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(30);
            RuleFor(x => x.Email).
                NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6)
                .MaximumLength(20);
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(30);
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required")
                .MaximumLength(30);
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required")
                .MaximumLength(50);
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(100);
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Postal code is required")
                .Matches("[0-9]{4}").WithMessage("Invalid postal code format.");
        }
    }
    public class UpdateMechanicViewModelValidator : AbstractValidator<UpdateMechanicViewModel>
    {
        public UpdateMechanicViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(x => x.Email).
                NotEmpty().
                EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(x => x.City)
                .NotEmpty().
                MaximumLength(30);
            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .Matches("[0-9]{4}");
        }
    }
    public class SignInMechanicViewModelValidator : AbstractValidator<SignInMechanicViewModel>
    {
        public SignInMechanicViewModelValidator()
        {
            RuleFor(x => x.Email).
                NotEmpty().
                EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);
        }
    }
    #endregion
    #region ViewModels
    public class MechanicGridViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
    public class ListMechanicGridViewModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public int InspectionsCount { get; set; }
        public int RatingCount { get; set; }
        public float AverageRating { get; set; }
    }

    [Validator(typeof(RegisterMechanicViewModelValidator))]
    public class RegisterMechanicViewModel {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Password { get; set; }
        public string  CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }

    public class UpdateMechanicViewModel {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }

    }
    [Validator(typeof(MechanicViewModelValidator))]

    public class MechanicViewModel : RegisterMechanicViewModel {
        public Guid Id { get; set; }
        public UserRole Role { get; set; }
    }
    [Validator(typeof(SignInMechanicViewModelValidator))]

    public class SignInMechanicViewModel {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    #endregion
}
