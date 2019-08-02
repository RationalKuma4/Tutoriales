using System;
using System.Collections.Generic;
using System.Text;

namespace Facs.Models
{
    public static class QuoteLoaderFactory
    {
        public static Func<IQuoteLoader> Create { get; set; }
    }
}
