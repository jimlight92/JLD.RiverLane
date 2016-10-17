using FluentValidation;
using JLD.RiverLane.Models;
using Ninject;
using System;
using System.Linq;

namespace JLD.RiverLane.Infrastructure.FluentValidation
{

    public class NinjectValidatorFactory : ValidatorFactoryBase
    {
        private readonly IKernel kernel;

        public NinjectValidatorFactory(IKernel kernel)
        {
            Check.NotNull(kernel, nameof(kernel));
            this.kernel = kernel;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var bindings = kernel.GetBindings(validatorType);

            if (!bindings.Any())
            {
                return null;
            }
            else
            {
                return kernel.Get(validatorType) as IValidator;
            }
        }
    }
}