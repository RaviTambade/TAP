using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;

public class MiniStatementService : IMiniStatementService
{
    private readonly IMiniStatementRepository _miniStatementRepo;

    public MiniStatementService(IMiniStatementRepository miniStatementRepo)
    {
        _miniStatementRepo=miniStatementRepo;
    }

    public List<MiniStatement> GetMiniStatement(int custId)=>_miniStatementRepo.GetMiniStatement(custId);

}