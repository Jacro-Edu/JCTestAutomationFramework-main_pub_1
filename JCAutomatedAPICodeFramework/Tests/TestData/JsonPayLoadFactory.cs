using AutoFixture;
using JCAutomatedAPICodeFramework.Models.Request;

namespace JCAutomatedAPICodeFramework.Tests.TestData
{
    public class JsonPayLoadFactory
    {
        private static readonly Fixture Fixture = new();

        public static CreateABoardRequest CreateRandomABoardPayload()
        {
            return Fixture.Build<CreateABoardRequest>()
               .With(x => x.Name, "Random Board name " + Fixture.Create<string>())
               .With(x => x.DefaultLabels, true)
               .With(x => x.DefaultLists, false)
               .With(x => x.IdOrganization, "443ssdsd0ca5e736922444cffa90ijjxhcxdDFDGGDa")
               .With(x => x.IdBoardSource, "")
               .With(x => x.KeepFromSource, "cards")
               .Create();
        }
        public static UpdateABoardRequest UpdateABoardPayload()
        {
            return Fixture.Build<UpdateABoardRequest>()
                .With(x => x.IdOrganization, "6jjj089ca5jue736922kjkhkj4445GDREERaqzxa")
                .With(x => x.Name, "Board name updated " + Fixture.Create<string>())
                .Create();
        }
        public static CreateACardRequest CreateACardPayload()
        {
            return Fixture.Build<CreateACardRequest>()
                .With(x => x.Name, "Random Card Name " + Fixture.Create<string>())
                .With(x => x.Desc, "Random Card description " + Fixture.Create<string>())
                .With(x => x.Pos, "top")
                .Create();
        }
    }
}
