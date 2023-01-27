using NUnit.Framework;

namespace DemoQA.Data
{
    public class TestContextValues
    {
        public static string ExecutableClassName => TestContext.CurrentContext.Test.ClassName;
    }
}
