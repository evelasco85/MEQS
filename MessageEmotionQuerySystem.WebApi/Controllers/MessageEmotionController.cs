using MessageAnalyzer.Base;
using MessageAnalyzer.Base.Model;
using MessageAnalyzer.en_US;
using MessageAnalyzerExecutionEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MessageEmotionQuerySystem.WebApi.Controllers
{
    public class MessageEmotionController : ApiController
    {
        public MessageEmotionController()
        {
            IMessageVerifierAlgorithm algorithm = new SentimentVerifierAlgorithm();
            ILocalization localization = new En_Us_Localization();

            ExecutionEngine.GetInstance().RegisterAnalyzer(localization, algorithm);
        }

        [HttpGet]
        public double GetMessageScore(string localizationCode, string message)
        {
            IMessage messageEntity = new Message
            {
                Content = new StringBuilder(message)
            };

            double score = ExecutionEngine.GetInstance().AnalyzeScore(localizationCode, messageEntity);

            return score;
        }
    }
}
