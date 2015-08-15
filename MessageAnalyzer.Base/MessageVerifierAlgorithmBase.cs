using MessageAnalyzer.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAnalyzer.Base
{
    public interface IMessageVerifierAlgorithm
    {
        float GetMessageWeigth(IMessage message, ILocalization localization);
    }

    public abstract class MessageVerifierAlgorithmBase : IMessageVerifierAlgorithm
    {
        public abstract float GetMessageWeigth(IMessage message, ILocalization localization);
    }
}
