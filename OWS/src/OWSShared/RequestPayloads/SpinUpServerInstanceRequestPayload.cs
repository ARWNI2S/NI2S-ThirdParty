namespace OWSShared.RequestPayloads
{
    public class SpinUpServerInstanceRequestPayload
    {
        public int WorldServerID { get; set; }
        public int ZoneInstanceID { get; set; }
        public string ZoneName { get; set; }
        public int Port { get; set; }
    }
}
