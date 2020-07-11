using System;

namespace ClassicDdd.Domain
{
    public class AccountId
    {
        public AccountId(string bankNo)
        {
            BankNo = bankNo;
        }

        public string BankNo { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AccountId no &&
                   BankNo == no.BankNo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BankNo);
        }
    }
}