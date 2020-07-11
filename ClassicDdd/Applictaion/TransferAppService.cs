using ClassicDdd.Domain;
using System;

namespace ClassicDdd.Applictaion
{
    public class TransferAppService
    {
        private readonly TransferDomainService _transferDomainService;

        public TransferAppService()
        {
            _transferDomainService = new TransferDomainService();
        }

        public void Transfer(string fromAccountNo, string toAccountNo, string transferMoneyStr)
        {
            if (!decimal.TryParse(transferMoneyStr, out decimal transferMoney))
            {
                throw new ArgumentException("金额输入错误！");
            }
            _transferDomainService.Transfer(new AccountId(fromAccountNo), new AccountId(toAccountNo), new Amount(transferMoney, Unit.圆));
        }
    }
}
