using System;

namespace ClassicDdd.Domain
{
    public class TransferDomainService
    {
        private readonly AccountRepository _accountRepository;

        private readonly TransferRecordRepository _transferRecordRepository;
        public TransferDomainService()
        {
            _accountRepository = new AccountRepository();
            _transferRecordRepository = new TransferRecordRepository();
        }

        public void Transfer(AccountId fromAccontId, AccountId toAccountId, Amount transferAmount)
        {
            Account fromAccount = _accountRepository.FindByAccountId(fromAccontId);
            Account toAccount = _accountRepository.FindByAccountId(toAccountId);
            if (fromAccount == null)
            {
                throw new ArgumentException("转出账户不存在！");
            }
            if (toAccount == null)
            {
                throw new ArgumentException("转入账户不存在！");
            }
            if (transferAmount == null)
            {
                throw new ArgumentException("金额不存在！");
            }
            if (fromAccount.Balance - transferAmount < Amount.Zero)
            {
                throw new ArgumentException("转出账户余额不够！");
            }
            fromAccount.Balance -= transferAmount;
            toAccount.Balance += transferAmount;
            TransferRecord transferRecord = new TransferRecord
            {
                FromAccountId = fromAccontId,
                ToAccountId = toAccountId,
                TransferMoney = transferAmount,
                TransferDate = DateTime.Now,
                Id = new TransferRecordId(Guid.NewGuid())
            };
            _accountRepository.Save(fromAccount);
            _accountRepository.Save(toAccount);
            _transferRecordRepository.Add(transferRecord);
        }
    }
}
