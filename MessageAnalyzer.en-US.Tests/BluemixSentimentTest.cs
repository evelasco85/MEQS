using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MessageAnalyzer.en_US.Tests
{
    [TestClass]
    public class BluemixSentimentTest
    {
        [TestMethod]
        public void TestGetMessageSentimentWeight()
        {
            double score = BluemixSentiment.GetInstance().GetMessageSentimentScore("I am sad");

            Assert.AreEqual(-0.857924, score);
        }
    }
}
