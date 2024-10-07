namespace OWSShared.Interfaces
{
    public interface IInstanceLauncherJob
    {
        void DoWork();
        void Dispose();
    }
}
