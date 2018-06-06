using System;
using Lab02_Unit_Testing;
using Xunit;

namespace Lab02_Unit_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(100, 40, true)]
        [InlineData(500, 600, false)]
        [InlineData(0, -100, false)]
        [InlineData(120, 120, true)]
        public void WithdrawalTest(double balance, double amount, bool expected)
        {
            Program.Balance = balance;
            Assert.Equal(expected, Program.Withdraw(amount));
        }

        [Theory]
        [InlineData(100, 40, true)]
        [InlineData(500, 600, true)]
        [InlineData(0, -100, false)]
        [InlineData(10, 0, false)]
        public void DepositTest(double balance, double amount, bool expected)
        {
            Program.Balance = balance;
            Assert.Equal(expected, Program.Deposit(amount));
        }
    }
}
