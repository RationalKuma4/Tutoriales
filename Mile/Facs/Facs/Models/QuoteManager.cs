using System;
using System.Collections.Generic;
using System.Text;

namespace Facs.Models
{
    public class QuoteManager
    {
        static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());

        public static QuoteManager Instance { get => instance.Value; }

        private QuoteManager()
        {
        }
    }
}
