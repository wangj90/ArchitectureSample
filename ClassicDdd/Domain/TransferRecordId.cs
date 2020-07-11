using System;

namespace ClassicDdd.Domain
{
    public class TransferRecordId
    {
        public TransferRecordId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TransferRecordId id &&
                   Id.Equals(id.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}