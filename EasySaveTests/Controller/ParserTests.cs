using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasySave.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Controller.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ParseNameTestEqual()
        {
            Parser parser = new Parser();
            Assert.AreEqual(parser.ParseName("name -option value"), "name");
        }

        [TestMethod()]
        public void ParseNameTestNotEqual()
        {
            Parser parser = new Parser();
            Assert.AreNotEqual(parser.ParseName("name -option value"), "name -option");
        }

        [TestMethod()]
        public void ParseOptionsTest()
        {
            Parser parser = new Parser();
            Dictionary<string, string> result = new Dictionary<string, string>
            {
                { "option1", "value1" },
                { "option2", "value2" }
            };

            Dictionary<string, string> test = parser.ParseOptions("name -option1 value1 -option2 value2");

            foreach (KeyValuePair<string, string> res in result)
            {
                if (!test.ContainsKey(res.Key))
                    Assert.Fail();

                Assert.AreEqual(res.Value, test[res.Key]);
            }
        }
    }
}