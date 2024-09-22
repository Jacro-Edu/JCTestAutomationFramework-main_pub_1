namespace JCAutomatedAPICodeFramework.Models.Response
{
    public class GetABoardResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public DescData? DescData { get; set; }
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
        public string? Memberships { get; set; }
        public string? ShortLink { get; set; }
        public bool? Subscribed { get; set; }
        public string? PowerUps { get; set; }
        public string? DateLastActivity { get; set; }
        public string? DateLastView { get; set; }
        public string? IdTags { get; set; }
        public string? DatePluginDisable { get; set; }
        public string? CreationMethod { get; set; }
        public int? IxUpdate { get; set; }
        public string? TemplateGallery { get; set; }
        public bool? EnterpriseOwned { get; set; }
    }
    public class PerboardForSingleBoard
    {
        public string? Status { get; set; }
        public int? DisableAt { get; set; }
        public int? WarnAt { get; set; }
    }
    public class DescData
    {
        public Emoji? Emoji { get; set; }
    }
}
