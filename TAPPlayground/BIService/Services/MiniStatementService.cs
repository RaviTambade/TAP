using BIService.Models;
using BIService.Repositories.Interfaces;
using BIService.Services.Interfaces;

namespace BIService.Services;

public class MiniStatementService : IMiniStatementService
{
    private readonly IMiniStatementRepository _miniStatementRepo;

    public MiniStatementService(IMiniStatementRepository miniStatementRepo)
    {
        _miniStatementRepo=miniStatementRepo;
    }

    public List<MiniStatement> GetMiniStatement(int custId)=>_miniStatementRepo.GetMiniStatement(custId);

}
