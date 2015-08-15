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
        int Weight { get; set; }
    }

    public class Message : IMessage
    {
        StringBuilder _content;
        string _source;
        int _weigth;

        public Message()
        {
            this._content = new StringBuilder();
            this._source = string.Empty;
            this._weigth = 0;
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

        public int Weight
        {
            get
            {
                return this._weigth;
            }
            set
            {
                this._weigth = value;
            }
        }
    }
}
