namespace EF360CodeOnly.Concurrency
{
    public class ConcurrencyResolutionStrategy
    {
        // This is the context class for the strategy pattern
        public static IConcurrencyResolution SelectResolution(ConcurrencyResolutionType concurrencyResolutionType)
        {
            switch (concurrencyResolutionType)
            {
                case ConcurrencyResolutionType.ClientWins:
                    return new ClientWinsStrategy();
                    break;
                case ConcurrencyResolutionType.ServerWins:
                    return new ServerWinsStrategy();
                    break;
                case ConcurrencyResolutionType.MergeResults:
                    return new MergeResultStrategy();
                    break;
                default:
                    return new ClientWinsStrategy();
                    break;
            }
        }
    }
}