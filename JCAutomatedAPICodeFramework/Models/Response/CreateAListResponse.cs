namespace JCAutomatedAPICodeFramework.Models.Response
{
    public class CreateAListResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Closed { get; set; }
        public object Color { get; set; }
        public string IdBoard { get; set; }
        public int Pos { get; set; }
        public Limits Limits { get; set; }
    }
}
