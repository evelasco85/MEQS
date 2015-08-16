using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAnalyzer.Base.Model
{
    public interface IMessage
    {
        StringBuilder Content { get; set; }
        string Source { get; set; }
        int Score { get; set; }
        StringBuilder Metadata { get; set; }
    }

    public class Message : IMessage
    {
        StringBuilder _content;
        StringBuilder _metadata;
        string _source;
        int _score;


        public Message()
        {
            this._metadata = new StringBuilder();
            this._content = new StringBuilder();
            this._source = string.Empty;
            this._score = 0;
        }

        public StringBuilder Metadata
        {
            get { return this._metadata; }
            set { this._metadata = value; }
        }

        public StringBuilder Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        public string Source
        {
            get
            {
                return this._source;
            }
            set
            {
                this._source = value;
            }
        }

        public int Score
        {
            get
            {
                return this._score;
            }
            set
            {
                this._score = value;
            }
        }
    }
}
