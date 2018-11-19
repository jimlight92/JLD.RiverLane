namespace JLD.RiverLane.Actions
{
    public class ResultWrapper<TPayload>
    {
        public ResultWrapper(TPayload payload)
        {
            Result = ResultType.Success;
            Payload = payload;
        }

        public ResultType Result { get; set; }

        public TPayload Payload { get; set; }
    }
}