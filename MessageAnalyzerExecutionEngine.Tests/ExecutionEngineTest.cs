using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageAnalyzer.Base;
using MessageAnalyzer.en_US;
using MessageAnalyzer.Base.Model;
using System.Text;

namespace MessageAnalyzerExecutionEngine.Tests
{
    [TestClass]
    public class ExecutionEngineTest
    {
        [TestMethod]
        public void TestAnalyzeScore()
        {
            IMessageVerifierAlgorithm algorithm = new SentimentVerifierAlgorithm();
            ILocalization localization = new  En_Us_Localization();

            ExecutionEngine.GetInstance().RegisterAnalyzer(localization, algorithm);

            string localizationCode = localization.LocalizationCode;
            IMessage message = new Message
            {
                 Content = new StringBuilder("I am sad")
            };

            double score = ExecutionEngine.GetInstance().AnalyzeScore(localizationCode, message);

            Assert.AreEqual(-0.857924, score);
        }
    }
}
