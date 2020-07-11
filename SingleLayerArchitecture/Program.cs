using System;
using System.Linq;

namespace SingleLayerArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new SingleLayerAtchitectureDbContext();
            Console.WriteLine("请输入转出账户");
            var fromAccountNo = Console.ReadLine();
            Console.WriteLine("请输入转入账户");
            var toAccountNo = Console.ReadLine();
            Console.WriteLine("请输入转账金额");
            var transferMoneyStr = Console.ReadLine();
            Account fromAccount = dbContext.Accounts.Where(a => a.BankCardNo == fromAccountNo).FirstOrDefault();
            Account toAccount = dbContext.Accounts.Where(a => a.BankCardNo == toAccountNo).FirstOrDefault();
            try
            {
                if (fromAccount == null)
                {
                    throw new ArgumentException("转出账户不存在！");
                }
                if (toAccount == null)
                {
                    throw new ArgumentException("转入账户不存在！");
                }
                if (!decimal.TryParse(transferMoneyStr, out decimal transferMoney))
                {
                    throw new ArgumentException("金额输入错误！");
                }
                if (fromAccount.Balance - transferMoney < 0)
                {
                    throw new ArgumentException("转出账户余额不够！");
                }
                fromAccount.Balance -= transferMoney;
                toAccount.Balance += transferMoney;
                TransferRecord transferRecord = new TransferRecord
                {
                    FromAccountId = fromAccount.Id,
                    ToAccountId = toAccount.Id,
                    TransferMoney = transferMoney,
                    TransferDate = DateTime.Now,
                    Id = Guid.NewGuid()
                };
                dbContext.Add(transferRecord);
                dbContext.SaveChanges();
                Console.WriteLine("转账成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
