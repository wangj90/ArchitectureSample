using System;

namespace ClassicDdd.Domain
{
    public class TransferRecord
    {
        public TransferRecordId Id { get; set; }

        public AccountId FromAccountId { get; set; }

        public AccountId ToAccountId { get; set; }

        public Amount TransferMoney { get; set; }

        public DateTime TransferDate { get; set; }
    }
}
