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
        public override float GetMessageWeigth(Base.Model.IMessage message, ILocalization localization)
        {
            throw new NotImplementedException();
        }
    }
}
