using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingleLayerArchitecture
{
    /// <summary>
    /// 转账记录
    /// </summary>
    [Table("TRANSFER_RECORD")]
    public class TransferRecord
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("ID")]
        public Guid Id { get; set; }
        /// <summary>
        /// 转出账户主键
        /// </summary>
        [Column("FROM_ACCOUNT_ID")]
        public Guid FromAccountId { get; set; }
        /// <summary>
        /// 转入账户主键
        /// </summary>
        [Column("TO_ACCOUNT_ID")]
        public Guid ToAccountId { get; set; }
        /// <summary>
        /// 转账金额
        /// </summary>
        [Column("TRANSFER_MONEY")]
        public decimal TransferMoney { get; set; }
        /// <summary>
        /// 转账时间
        /// </summary>
        [Column("TRANSFER_DATE")]
        public DateTime TransferDate { get; set; }
    }
}
