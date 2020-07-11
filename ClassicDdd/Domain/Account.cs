using System;
using System.ComponentModel.DataAnnotations;

namespace ClassicDdd.Domain
{
    public class Account
    {
        public AccountId AccountId { get; set; }

        public AccountPerson Person { get; set; }

        public AccountPhone Phone { get; set; }

        public Amount Balance { get; set; }
    }
}
