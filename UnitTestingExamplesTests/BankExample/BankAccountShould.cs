using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingExamples.BankExample;
using UnitTestingExamples.Providers;

namespace UnitTestingExamplesTests.BankExample
{
    [TestClass]
    public class BankAccountShould
    {
        [TestMethod]
        public void SetCorrectDateTimeToTransaction()
        {
            var expectedDateTime = new DateTime(2016, 4, 6);

            using (var date = DateTimeProvider.InjectActualDateTime(expectedDateTime))
            {
                var bankAccount = new BankAccount();

                bankAccount.DepositMoney(600);

                var lastTransaction = bankAccount.Transactions.Last();

                Assert.IsTrue(expectedDateTime.Equals(bankAccount.Transactions[0].TransactionDate));
            }
        }
    }
}
