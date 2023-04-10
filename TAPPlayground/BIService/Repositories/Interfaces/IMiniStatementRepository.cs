using BIService.Models;

namespace BIService.Repositories.Interfaces;

public interface IMiniStatementRepository
{
    public List<MiniStatement> GetMiniStatement(int custid);
}