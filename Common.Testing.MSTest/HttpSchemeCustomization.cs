using Ploeh.AutoFixture;

namespace Common.Testing.MSTest
{
    public class HttpSchemeCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Inject(new UriScheme("http"));
        }
    }
}