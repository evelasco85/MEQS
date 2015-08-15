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
        double GetMessageWeigth(IMessage message, ILocalization localization);
    }

    public abstract class MessageVerifierAlgorithmBase : IMessageVerifierAlgorithm
    {
        public abstract double GetMessageWeigth(IMessage message, ILocalization localization);
    }
}
