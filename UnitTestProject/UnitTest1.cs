using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EasySave.View.View view = new EasySave.View.View();
            EasySave.Model.Model model = new EasySave.Model.Model();
            EasySave.Controller.Controller control = new EasySave.Controller.Controller(model, view);
            
        }
    }
}
