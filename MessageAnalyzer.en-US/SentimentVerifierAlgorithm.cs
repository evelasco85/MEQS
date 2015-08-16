using MessageAnalyzer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAnalyzer.en_US
{
    public class SentimentVerifierAlgorithm : MessageVerifierAlgorithmBase
    {
        public override double GetMessageWeigth(Base.Model.IMessage message, ILocalization localization)
        {
            double score = BluemixSentiment.GetInstance().GetMessageSentimentScore(message.Content.ToString());

            BluemixSentiment.GetInstance().PersistMessage(message.Metadata);

            return score;
        }
    }
}
