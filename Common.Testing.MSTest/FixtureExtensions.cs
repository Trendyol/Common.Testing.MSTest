using Ploeh.AutoFixture;

namespace Common.Testing.MSTest
{
    public static class FixtureExtensions
    {
        /// <summary>
        ///  Customize Fixture behavior
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fixture"></param>
        public static void EnableCustomization<T>(this IFixture fixture) where T : ICustomization, new()
        {
            new T().Customize(fixture);
        }

        /// <summary>
        /// Customize Fixture behavior
        /// </summary>
        /// <param name="fixture"></param>
        /// <param name="customization"></param>
        public static void EnableCustomization(this IFixture fixture,ICustomization customization)
        {
            customization.Customize(fixture);
        }
    }
}