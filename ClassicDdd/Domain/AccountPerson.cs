using System;

namespace ClassicDdd.Domain
{
    public class AccountPerson
    {
        public string PersonName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AccountPerson person &&
                   PersonName == person.PersonName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PersonName);
        }
    }
}