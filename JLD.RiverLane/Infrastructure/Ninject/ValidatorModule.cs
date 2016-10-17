using FluentValidation;
using FluentValidation.Mvc;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using JLD.RiverLane.Infrastructure.FluentValidation;

namespace JLD.RiverLane.Infrastructure.Ninject
{
    public class ValidatorModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllClasses()
                 .InheritedFrom(typeof(IValidator<>))
                 .BindAllInterfaces();
            });

            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = new NinjectValidatorFactory(Kernel));
        }
    }
}