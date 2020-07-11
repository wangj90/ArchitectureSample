using SingleLayerArchitecture;
using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayerArchitecture.DAL;

namespace ThreeLayerArchitecture.BLL
{
    public class TransferBLL
    {
        public void transfer(string fromAccountNo, string toAccountNo, string transferMoneyStr)
        {
            AccountDAL accountDAL = new AccountDAL();
            TransferRecordDAL transferRecordDAL = new TransferRecordDAL();
            Account fromAccount = accountDAL.FindByAccountNo(fromAccountNo);
            Account toAccount = accountDAL.FindByAccountNo(toAccountNo);
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
            accountDAL.Save(fromAccount);
            accountDAL.Save(toAccount);
            transferRecordDAL.Add(transferRecord);
        }
    }
}
