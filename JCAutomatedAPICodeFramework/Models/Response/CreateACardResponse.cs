namespace JCAutomatedAPICodeFramework.Models.Response
{
    public class CreateACardResponse
    {
        public string? Id { get; set; }
        public string? Address { get; set; }
        public Badges? Badges { get; set; }
        public string[]? CheckItemStates { get; set; }
        public bool Closed { get; set; }
        public string? Coordinates { get; set; }
        public string? CreationMethod { get; set; }
        public DateTime? DateLastActivity { get; set; }
        public string? Desc { get; set; }
        public Descdata? DescData { get; set; }
        public string? Due { get; set; }
        public string? DueReminder { get; set; }
        public string? Email { get; set; }
        public string? IdBoard { get; set; }
        public Idchecklist[]? IdChecklists { get; set; }
        public Idlabel[]? IdLabels { get; set; }
        public string? IdList { get; set; }
        public string[]? IdMembers { get; set; }
        public string[]? IdMembersVoted { get; set; }
        public int? IdShort { get; set; }
        public string[]? Labels { get; set; }
        public Limits? Limits { get; set; }
        public string? LocationName { get; set; }
        public bool? ManualCoverAttachment { get; set; }
        public string? Name { get; set; }
        public int? Pos { get; set; }
        public string? ShortLink { get; set; }
        public string? ShortUrl { get; set; }
        public bool? Subscribed { get; set; }
        public string? Rrl { get; set; }
        public Cover? Cover { get; set; }
    }
    public class Idchecklist
    {
        public string? Id { get; set; }
    }
    public class Idlabel
    {
        public string? Id { get; set; }
        public string? IdBoard { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
    }
}
