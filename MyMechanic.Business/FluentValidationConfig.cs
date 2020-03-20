using FluentValidation.Mvc;

namespace MyMechanic.Business
{
    public class FluentValidationConfig
    {
        public static void Configure()
        {
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
