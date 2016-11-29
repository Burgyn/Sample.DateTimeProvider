using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingExamples.BankExample
{
    public class Transaction
    {
        public string AccountNumber { get; set; }

        public double Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }
    }
}
