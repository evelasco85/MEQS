using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace MessageAnalyzer.en_US.Tests
{
    [TestClass]
    public class BluemixSentimentTest
    {
        [TestMethod]
        public void TestGetMessageSentimentWeight()
        {
            StringBuilder jsonData = BluemixSentiment.GetInstance().GetMessageSentimentWeight("I am sad");

            Assert.IsNotNull(jsonData);
        }
    }
}
