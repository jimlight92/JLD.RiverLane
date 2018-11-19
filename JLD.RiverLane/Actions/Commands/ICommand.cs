using System.Threading.Tasks;

namespace JLD.RiverLane.Actions.Commands
{
    public interface ICommand<in TIn, TOut>
    {
        Task<ResultWrapper<TOut>> ExecuteAsync(TIn model);
    }

    public interface ICommand<in TIn> : ICommand<TIn, Unit>
    {
    }
}