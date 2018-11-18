using BaseClasses.Fixtures;
using BaseClasses.Helpers;
using FluentValidation;
using JLD.RiverLane.DataAccess;
using JLD.RiverLane.Infrastructure.FluentValidation;
using JLD.RiverLane.Models;

namespace JLD.RiverLane.ViewModels
{
    public abstract class ViewModelValidator<T> : AbstractValidator<T>
        where T : class
    {
        protected IContextFactory Factory { get; }

        /// <summary>
        /// Initialises a new instance of a <see cref="ViewModelValidator{T}"/> with an <see cref="IContextFactory"/>  
        /// </summary>
        /// <param name="factory"></param>
        protected ViewModelValidator(IContextFactory factory)
        {
            Check.NotNull(factory, nameof(factory));
            Factory = factory;
            
            SetRules(factory.CreateContext());
        }

        /// <summary>
        /// Initialises a new instance of a <see cref="ViewModelValidator{T}"/> with a <see cref="RiverLaneContext"/> already made
        /// </summary>
        /// <param name="factory"></param>
        protected ViewModelValidator(RiverLaneContext context)
        {
            Check.NotNull(context, nameof(context));
            SetRules(context);
        }

        protected abstract void SetRules(RiverLaneContext context);
    }
}