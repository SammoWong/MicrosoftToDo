using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp.Core;

namespace ToDoApp.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ToDoContext context = new ToDoContext(Constants.DatabasePath);
            Constants.InitAsync(context);
        }
    }
}
