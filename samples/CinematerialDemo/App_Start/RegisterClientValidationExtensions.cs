using CinematerialDemo;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof(RegisterClientValidationExtensions), "Start")]

namespace CinematerialDemo
{
    using DataAnnotationsExtensions.ClientValidation;

    public static class RegisterClientValidationExtensions
    {
        public static void Start()
        {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();
        }
    }
}