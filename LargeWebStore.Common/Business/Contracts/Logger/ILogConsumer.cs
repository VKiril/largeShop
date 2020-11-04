namespace LargeWebStore.Common.Business.Contracts.Logger
{
    public interface ILogConsumer
    {
        string Message { get; }
        string Origin { get; }
    }
}
