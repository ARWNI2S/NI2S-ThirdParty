namespace OWSShared.Interfaces
{
    public interface IRequestHandler<TRequest, TResponse> //where request : Request
    {
        Task<TResponse> Handle();
    }

    public interface IRequestHandler<TRequest> //where request : Request
    {
        Task Handle();
    }
}
