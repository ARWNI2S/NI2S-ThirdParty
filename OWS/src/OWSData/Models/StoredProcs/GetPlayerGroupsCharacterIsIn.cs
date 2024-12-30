namespace OWSData.Models.StoredProcs
{
    public class GetPlayerGroupsCharacterIsIn
    {
        public int PlayerGroupID { get; set; }
        public Guid CustomerGUID { get; set; }
        public string PlayerGroupName { get; set; }
        public int PlayerGroupTypeID { get; set; }
        public int ReadyState { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
