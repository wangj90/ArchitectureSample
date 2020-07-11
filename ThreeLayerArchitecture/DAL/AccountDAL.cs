using Microsoft.Data.SqlClient;
using SingleLayerArchitecture;
using System.Linq;

namespace ThreeLayerArchitecture.DAL
{
    public class AccountDAL
    {

        public Account FindByAccountNo(string accountNo)
        {
            using var dbContext = new ThreeLayerAtchitectureDbContext();
            return dbContext.Accounts.Where(a => a.BankCardNo == accountNo).FirstOrDefault();
        }

        public void Save(Account account)
        {
            using var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ThreeLayerArchitecture;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            string sql = @"update ACCOUNT set BALANCE = " + account.Balance + " where BANK_CARD_NO = '" + account.BankCardNo + "';";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
