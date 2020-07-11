using System;

namespace ClassicDdd.Domain
{

    public enum Unit
    {
        圆, 角, 分
    }
    /// <summary>
    /// 金额
    /// </summary>
    public class Amount
    {
        public Amount(decimal balanceQty, Unit unit)
        {
            BalanceQty = balanceQty;
            Unit = unit;
        }

        /// <summary>
        /// 金额数字
        /// </summary>
        public decimal BalanceQty { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public Unit Unit { get; set; }
        public static Amount Zero
        {
            get
            {
                return new Amount(0, Unit.圆);
            }
        }

        public static Amount operator -(Amount a, Amount b)
        {
            Amount aYuan = TransferToYuan(a);
            Amount bYuan = TransferToYuan(b);
            return new Amount(aYuan.BalanceQty - bYuan.BalanceQty, Unit.圆);
        }

        public static Amount operator +(Amount a, Amount b)
        {
            Amount aYuan = TransferToYuan(a);
            Amount bYuan = TransferToYuan(b);
            return new Amount(aYuan.BalanceQty + bYuan.BalanceQty, Unit.圆);
        }

        public static bool operator <(Amount a, Amount b)
        {
            Amount aYuan = TransferToYuan(a);
            Amount bYuan = TransferToYuan(b);
            return aYuan.BalanceQty < bYuan.BalanceQty;
        }

        public static bool operator >(Amount a, Amount b)
        {
            Amount aYuan = TransferToYuan(a);
            Amount bYuan = TransferToYuan(b);
            return aYuan.BalanceQty > bYuan.BalanceQty;
        }

        private static Amount TransferToYuan(Amount a)
        {
            int aUnitInt = (int)a.Unit;
            return new Amount(a.BalanceQty / Convert.ToDecimal(Math.Pow(10, aUnitInt)), Unit.圆);
        }
    }
}