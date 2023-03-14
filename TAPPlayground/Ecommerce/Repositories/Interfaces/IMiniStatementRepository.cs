using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface IMiniStatementRepository
{
    public List<MiniStatement> GetMiniStatement(int custid);
}