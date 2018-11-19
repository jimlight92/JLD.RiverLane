namespace JLD.RiverLane.Actions.Commands
{
    public interface ICommand<in TIn, TOut>
    {
        ResultWrapper<TOut> Execute(TIn model);
    }

    public interface ICommand<in TIn> : ICommand<TIn, Unit>
    {
    }
}