using JLD.RiverLane.DataAccess;

namespace JLD.RiverLane.Infrastructure.FluentValidation
{
    /// <summary>
    /// Contains code for creating a context that can be injected into FluentValidation Validators
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
	public interface IContextFactory
	{
        RiverLaneContext CreateContext();
	}
}