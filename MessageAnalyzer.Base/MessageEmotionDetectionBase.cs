using MessageAnalyzer.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAnalyzer.Base
{
    public interface IMessageEmotionDetection
    {
        int GetMessageWeigth(IMessageVerifierAlgorithm algorithm, ILocalization localization, IMessage message);
    }

    public abstract class MessageEmotionDetectionBase : IMessageEmotionDetection
    {
        public abstract int GetMessageWeigth(IMessageVerifierAlgorithm algorithm, ILocalization localization, IMessage message);
    }
}
