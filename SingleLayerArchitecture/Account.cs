using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingleLayerArchitecture
{
    /// <summary>
    /// 账户
    /// </summary>
    [Table("ACCOUNT")]
    public class Account
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("ID")]
        public Guid Id { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        [Column("BANK_CARD_NO")]
        public string BankCardNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("PERSON_NAME")]
        public string PersonName { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [Column("PHONE_NO")]
        public string PhoneNo { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        [Column("BALANCE")]
        public decimal Balance { get; set; }
    }
}
