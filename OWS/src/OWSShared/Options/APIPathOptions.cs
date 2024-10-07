namespace OWSShared.Options
{
    public class APIPathOptions
    {
        public const string SectionName = "OWSAPIPathConfig";
        public string InternalPublicApiURL { get; set; }
        public string InternalInstanceManagementApiURL { get; set; }
        public string InternalCharacterPersistenceApiURL { get; set; }
    }
}
