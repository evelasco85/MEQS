using MessageAnalyzer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MessageAnalyzer.Base.Model;

namespace MessageAnalyzerExecutionEngine
{
    public interface IExecutionEngine
    {
        void RegisterAnalyzer(ILocalization localization, IMessageVerifierAlgorithm algorithm);
        double AnalyzeScore(string localizationCode, IMessage message);
    }

    public class ExecutionEngine : IExecutionEngine
    {
        static IExecutionEngine _instance;
        IDictionary<ILocalization, IMessageVerifierAlgorithm> _algorithms;

        public static IExecutionEngine GetInstance()
        {
            if(_instance == null)
                _instance = new ExecutionEngine();

            return _instance;
        }

        private ExecutionEngine()
        {
            this._algorithms = new Dictionary<ILocalization, IMessageVerifierAlgorithm>();
        }

        public void RegisterAnalyzer(ILocalization localization, IMessageVerifierAlgorithm algorithm)
        {
            if ((localization == null) || (this._algorithms.Where(x => x.Key.LocalizationCode == localization.LocalizationCode).Any()))
                return;

            this._algorithms.Add(new KeyValuePair<ILocalization, IMessageVerifierAlgorithm>(localization, algorithm));
        }

        IMessageVerifierAlgorithm GetAlgorithm(string localizationCode)
        {
            IMessageVerifierAlgorithm algorithm = this._algorithms
                .Where(x => x.Key.LocalizationCode == localizationCode)
                .Select(x => x.Value)
                .DefaultIfEmpty(null)
                .FirstOrDefault();

            return algorithm;
        }

        ILocalization GetLocalization(string localizationCode)
        {
            return this._algorithms
                .Where(x => x.Key.LocalizationCode == localizationCode)
                .Select(x => x.Key)
                .DefaultIfEmpty(null)
                .FirstOrDefault();
        }

        public double AnalyzeScore(string localizationCode, IMessage message)
        {
            double score = 0;


            IMessageVerifierAlgorithm algorithm = this.GetAlgorithm(localizationCode);
            ILocalization localization = this.GetLocalization(localizationCode);

            score = algorithm.GetMessageWeigth(message, localization);

            return score;
        }
    }
}
