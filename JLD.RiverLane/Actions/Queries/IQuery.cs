using System.Threading.Tasks;

namespace JLD.RiverLane.Actions.Queries
{
    public interface IQuery<in TIn, TOut>
    {
        Task<ResultWrapper<TOut>> ExecuteAsync(TIn model);
    }

    public interface IQuery<TOut> : IQuery<Unit, TOut>
    {
    }
}