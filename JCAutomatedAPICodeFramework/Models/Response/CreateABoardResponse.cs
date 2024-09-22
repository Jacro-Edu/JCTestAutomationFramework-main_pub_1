namespace JCAutomatedAPICodeFramework.Models.Response
{
    public class CreateABoardResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public Descdata? DescData { get; set; }
        public bool? Closed { get; set; }
        public string? IdOrganization { get; set; }
        public object? IdEnterprise { get; set; }
        public bool? Pinned { get; set; }
        public string? Url { get; set; }
        public string? ShortUrl { get; set; }
        public Prefs? Prefs { get; set; }
        public Labelnames? LabelNames { get; set; }
        public Limits? Limits { get; set; }
    }
    public class Switcherview
    {
        public string? ViewType { get; set; }
        public bool? Enabled { get; set; }
    }
}
