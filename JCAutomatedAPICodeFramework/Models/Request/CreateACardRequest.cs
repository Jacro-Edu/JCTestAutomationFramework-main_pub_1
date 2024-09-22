namespace JCAutomatedAPICodeFramework.Models.Request
{
    public class CreateACardRequest
    {
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public string? Pos { get; set; }
        public bool DueComplete { get; set; }
    }
}
