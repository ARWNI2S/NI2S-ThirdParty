namespace OWSData.Repositories.Interfaces
{
    public interface IOWSInstanceLauncherDataRepository
    {
        void SetWorldServerID(int worldServerID);
        int GetWorldServerID();

        void SetLauncherGuid(Guid launcherGuid);
        Guid GetLauncherGuid();
    }
}
