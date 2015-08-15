using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAnalyzer.Base
{
    public interface ILocalization
    {
        string LocalizationCode { get; }
    }


    public abstract class LocalizationBase : ILocalization
    {
        public abstract string LocalizationCode { get; }
    }
}
