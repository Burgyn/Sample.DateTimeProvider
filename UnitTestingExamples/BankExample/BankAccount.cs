using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingExamples.Providers;

namespace UnitTestingExamples.BankExample
{
    /// <summary>
    /// Bank account
    /// </summary>
    public class BankAccount
    {
        private List<Transaction> _transactions = new List<Transaction>();

        /// <summary>
        /// Actual bank account balance.
        /// </summary>
        public double Balance =>_transactions.Sum(p => p.Amount);

        /// <summary>
        /// Existing transactions.
        /// </summary>        
        public List<Transaction> Transactions => _transactions;

        /// <summary>
        /// Deposits the money.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="System.ArgumentException">Argument 'amount' cannot be less than zerro.;amount</exception>
        public void DepositMoney(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Argument 'amount' cannot be less than zerro.", "amount");
            }

            this.MakeTransaction(new Transaction()
            {
                Amount = amount,
                Description = "Deposit money"
            });
        }

        /// <summary>
        /// Withdraws the money.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="System.ArgumentException">Argument 'amount' cannot be less than zerro.;amount</exception>
        public void WithdrawMoney(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Argument 'amount' cannot be less than zerro.", "amount");
            }

            this.MakeTransaction(new Transaction()
            {
                Amount = -amount,
                Description = "Withdraw money"
            });
        }

        private void MakeTransaction(Transaction transaction)
        {
            transaction.TransactionDate = DateTimeProvider.Now;
            _transactions.Add(transaction);
        }

    }
}
