using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace MessageAnalyzer.en_US
{
    public interface IBluemixSentiment
    {
        double GetMessageSentimentScore(string content);
        void PersistMessage(StringBuilder metadata);
    }

    public class BluemixSentiment : IBluemixSentiment
    {
        static IBluemixSentiment _sentiment;

        public static IBluemixSentiment GetInstance()
        {
            if (_sentiment == null)
                _sentiment = new BluemixSentiment();

            return _sentiment;
        }

        private BluemixSentiment() { }

        public double GetMessageSentimentScore(string content)
        {
            string url = "http://sentimentprovider.mybluemix.net";
            string function = "RetrieveMessageSentimentWeight";
            string parameter = string.Format("messageContent={0}", content);

            string completeUrl = string.Format("{0}/{1}?{2}", url, function, parameter);
            StringBuilder jsonData = RequestProcessor.GetInstance().SendRequest(null, "application/json", completeUrl, "application/json; charset=utf-8", "GET", null, 3000);

            double score = 0;

            if ((jsonData != null) && (!string.IsNullOrEmpty(jsonData.ToString())))
            {
                JObject jsonResult = JObject.Parse(jsonData.ToString());

                object scoreString = jsonResult["doc-sentiment"]["score"];

                if (scoreString != null)
                    score = Convert.ToDouble(scoreString.ToString());
            }

            return score;
        }

        public void PersistMessage(StringBuilder metadata)
        {
            string url = "http://sentimentprovider.mybluemix.net";
            string function = "PersistMessageMetadata";

            string completeUrl = string.Format("{0}/{1}", url, function);
            StringBuilder jsonData = RequestProcessor.GetInstance().SendRequest(null, "application/json", completeUrl, "application/json; charset=utf-8", "POST", metadata, 3000);

        }
    }
}
