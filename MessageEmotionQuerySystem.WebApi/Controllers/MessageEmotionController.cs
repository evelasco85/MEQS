using MessageAnalyzer.Base;
using MessageAnalyzer.Base.Model;
using MessageAnalyzer.en_US;
using MessageAnalyzerExecutionEngine;
using MessageEmotionQuerySystem.WebApi.Handler;
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

        [HttpPost]
        public string GetMessageScores(string localizationCode, string messages)
        {
            string completeMessages = this.GetRequestContent(this);

            string scores = ExecutionEngine.GetInstance().AnalyzeScores(localizationCode, completeMessages);

            return scores;
        }

        public string GetRequestContent(ApiController controller)
        {
            StringBuilder content = new StringBuilder();

            ContentHandler handler = controller.Request
                .GetConfiguration()
                .MessageHandlers
                .Where(customHandler => customHandler.GetType() == typeof(ContentHandler))
                .FirstOrDefault() as ContentHandler;

            if ((handler != null) && (handler.RequestContent != null))
                content = handler.RequestContent;

            return content.ToString();
        }
    }
}
