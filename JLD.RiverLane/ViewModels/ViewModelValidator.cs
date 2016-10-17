using FluentValidation;

namespace JLD.RiverLane.ViewModels
{
    public class ViewModelValidator<T> : AbstractValidator<T>
        where T : class
    {
    }
}