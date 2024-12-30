namespace OWSShared.Interfaces
{
    public interface IInstanceLauncherJob
    {
        Task DoWorkAsync();
        void Dispose();
    }
}
