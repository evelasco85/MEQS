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
            StringBuilder jsonData = BluemixSentiment.GetInstance().GetMessageSentimentWeight("I am sad");

            JObject jsonResult = JObject.Parse(jsonData.ToString());

            string score = jsonResult["doc-sentiment"]["score"].ToString();

            Assert.AreEqual(-0.857924, Convert.ToDouble(score));
        }
    }
}
