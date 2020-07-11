using System;

namespace ClassicDdd.Domain
{
    public class AccountPhone
    {
        public string PhoneNo { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AccountPhone phone &&
                   PhoneNo == phone.PhoneNo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PhoneNo);
        }
    }
}