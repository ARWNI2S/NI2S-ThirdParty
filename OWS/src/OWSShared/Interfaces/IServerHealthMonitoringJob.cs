namespace OWSShared.Interfaces
{
    public interface IServerHealthMonitoringJob
    {
        void DoWork();
        void Dispose();
    }
}
