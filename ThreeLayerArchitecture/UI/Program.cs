using System;
using ThreeLayerArchitecture.BLL;

namespace ThreeLayerArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入转出账户");
            var fromAccountNo = Console.ReadLine();
            Console.WriteLine("请输入转入账户");
            var toAccountNo = Console.ReadLine();
            Console.WriteLine("请输入转账金额");
            var transferMoneyStr = Console.ReadLine();
            try
            {
                var bll = new TransferBLL();
                bll.transfer(fromAccountNo, toAccountNo, transferMoneyStr);
                Console.WriteLine("转账成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
