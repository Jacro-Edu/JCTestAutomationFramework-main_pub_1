namespace JCAutomatedAPICodeFramework.Models.Request
{
    public class CreateABoardRequest
    {
        public string? Name { get; set; }
        public bool DefaultLabels { get; set; }
        public bool DefaultLists { get; set; }
        public string? Desc { get; set; }
        public string? IdOrganization { get; set; }
        public string? IdBoardSource { get; set; }
        public string? KeepFromSource { get; set; }
    }
}
