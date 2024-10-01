using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace page_retriever
{
    class TickerInfo
    {
        public readonly string symbol;
        public readonly string url;
        public readonly bool isLastLine;

        public TickerInfo(string symbol, string url)
        {
            this.symbol = symbol;
            this.url = url;
            this.isLastLine = !(symbol.Length > 0 && url.Length > 0);
        }
    }
}
