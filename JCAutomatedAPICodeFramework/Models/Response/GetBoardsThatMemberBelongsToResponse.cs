namespace JCAutomatedAPICodeFramework.Models.Response
{
    public class GetBoardsThatMemberBelongsToResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public Descdata? DescData { get; set; }
        public bool? Closed { get; set; }
        public string? IdMemberCreator { get; set; }
        public string? IdOrganization { get; set; }
        public bool? Pinned { get; set; }
        public string? Url { get; set; }
        public string? ShortUrl { get; set; }
        public Prefs? Prefs { get; set; }
        public Labelnames? LabelNames { get; set; }
        public Limits? Limits { get; set; }
        public bool? Starred { get; set; }
        public Memberships[]? Memberships { get; set; }
        public string? ShortLink { get; set; }
        public bool? Subscribed { get; set; }
        public List<string>? PowerUps { get; set; }
        public string? DateLastActivity { get; set; }
        public string? DateLastView { get; set; }
        public List<string>? IdTags { get; set; }
        public string? DatePluginDisable { get; set; }
        public string? CreationMethod { get; set; }
        public int? IxUpdate { get; set; }
        public string? TemplateGallery { get; set; }
        public bool? EnterpriseOwned { get; set; }
    }
    public class Prefs
    {
        public string? PermissionLevel { get; set; }
        public bool? HideVotes { get; set; }
        public string? Voting { get; set; }
        public string? Comments { get; set; }
        public bool? SelfJoin { get; set; }
        public bool? CardCovers { get; set; }
        public bool? IsTemplate { get; set; }
        public string? CardAging { get; set; }
        public bool? CalendarFeedEnabled { get; set; }
        public string? Background { get; set; }
        public string? BackgroundImage { get; set; }
        public Backgroundimagescaled[]? BackgroundImageScaled { get; set; }
        public bool? BackgroundTile { get; set; }
        public string? BackgroundBrightness { get; set; }
        public string? BackgroundBottomColor { get; set; }
        public string? BackgroundTopColor { get; set; }
        public bool? CanBePublic { get; set; }
        public bool? CanBeEnterprise { get; set; }
        public bool? CanBeOrg { get; set; }
        public bool? CanBePrivate { get; set; }
        public bool? CanInvite { get; set; }
    }
    public class Backgroundimagescaled
    {
        public int? Width { get; set; }
        public int Height { get; set; }
        public string? Url { get; set; }
    }
    public class Labelnames
    {
        public string? Green { get; set; }
        public string? Yellow { get; set; }
        public string? Orange { get; set; }
        public string? Red { get; set; }
        public string? Purple { get; set; }
        public string? Blue { get; set; }
        public string? Sky { get; set; }
        public string? Lime { get; set; }
        public string? Pink { get; set; }
        public string? Black { get; set; }
    }
    public class Limits
    {
        public Attachments? Attachments { get; set; }
    }
    public class Attachments
    {
        public Perboard? PerBoard { get; set; }
    }
    public class Perboard
    {
    }
    public class Memberships
    {
        public string? IdMember { get; set; }
        public string? MemberType { get; set; }
        public bool? Unconfirmed { get; set; }
        public bool? Deactivated { get; set; }
        public string? Id { get; set; }
    }
}
