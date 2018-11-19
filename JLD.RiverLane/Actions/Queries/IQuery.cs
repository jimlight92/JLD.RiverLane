namespace JLD.RiverLane.Actions.Queries
{
    public interface IQuery<in TIn, TOut>
    {
        ResultWrapper<TOut> Execute(TIn model);
    }

    public interface IQuery<TOut> : IQuery<Unit, TOut>
    {
    }
}