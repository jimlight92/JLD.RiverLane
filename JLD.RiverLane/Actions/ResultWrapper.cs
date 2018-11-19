namespace JLD.RiverLane.Actions
{
    public class ResultWrapper<TPayload>
    {
        public ResultType Result { get; set; }

        public TPayload Payload { get; set; }
    }
}