namespace JLD.RiverLane.DataAccess.Conventions
{
    public class TableNameConvention : UpperCaseSplitConvention
    {
        public TableNameConvention()
        {
            Types().Configure(x => x.ToTable(GetUpperCaseSplit(x.ClrType.Name)));
        }
    }
}