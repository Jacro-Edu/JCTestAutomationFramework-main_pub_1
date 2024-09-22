namespace JCAutomatedAPICodeFramework.Models.Response
{
    public class GetAllCardsOnABoardResponse
    {
        public string? Id { get; set; }
        public Badges? Badges { get; set; }
        public object[]? CheckItemStates { get; set; }
        public bool? Closed { get; set; }
        public bool? DueComplete { get; set; }
        public DateTime? DateLastActivity { get; set; }
        public string? Desc { get; set; }
        public Descdata? DescData { get; set; }
        public object? Due { get; set; }
        public object? DueReminder { get; set; }
        public object? Email { get; set; }
        public string? IdBoard { get; set; }
        public object[]? IdChecklists { get; set; }
        public string? IdList { get; set; }
        public object[]? IdMembers { get; set; }
        public object[]? IdMembersVoted { get; set; }
        public int? IdShort { get; set; }
        public object? IdAttachmentCover { get; set; }
        public object[]? Labels { get; set; }
        public object[]? IdLabels { get; set; }
        public bool? ManualCoverAttachment { get; set; }
        public string? Name { get; set; }
        public double? Pos { get; set; }
        public string? ShortLink { get; set; }
        public string? ShortUrl { get; set; }
        public object? Start { get; set; }
        public bool? Subscribed { get; set; }
        public string? Url { get; set; }
        public Cover? Cover { get; set; }
        public bool? IsTemplate { get; set; }
        public object? CardRole { get; set; }
    }
    public class Badges
    {
        public Attachmentsbytype? AttachmentsByType { get; set; }
        public bool? Location { get; set; }
        public int? Votes { get; set; }
        public bool? ViewingMemberVoted { get; set; }
        public bool? Subscribed { get; set; }
        public string? Fogbugz { get; set; }
        public int? CheckItems { get; set; }
        public int? CheckItemsChecked { get; set; }
        public object? CheckItemsEarliestDue { get; set; }
        public int? Comments { get; set; }
        public int? Attachments { get; set; }
        public bool? Description { get; set; }
        public object? Due { get; set; }
        public bool? DueComplete { get; set; }
        public object? Start { get; set; }
    }
    public class Attachmentsbytype
    {
        public Trello? Trello { get; set; }
    }
    public class Trello
    {
        public int? Board { get; set; }
        public int? Card { get; set; }
    }
    public class Descdata
    {
        public Emoji? Emoji { get; set; }
    }
    public class Emoji
    {
    }
    public class Cover
    {
        public object? IdAttachment { get; set; }
        public object? Color { get; set; }
        public object? IdUploadedBackground { get; set; }
        public string? Size { get; set; }
        public string? Brightness { get; set; }
        public object? IdPlugin { get; set; }
    }
}
