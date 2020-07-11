
using SingleLayerArchitecture;

namespace ThreeLayerArchitecture.DAL
{
    public class TransferRecordDAL
    {
        public int Add(TransferRecord transferRecord)
        {
            using var dbContext = new ThreeLayerAtchitectureDbContext();
            dbContext.Add(transferRecord);
            return dbContext.SaveChanges();
        }
    }
}
