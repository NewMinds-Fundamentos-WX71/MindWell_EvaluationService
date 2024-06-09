using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class TestService : ITestService
{
    private readonly ITestRepository _testRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TestService(ITestRepository testRepository, IUnitOfWork unitOfWork)
    {
        _testRepository = testRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Test>> ListAsync()
    {
        return await _testRepository.FidnAllAsync();
    }

    public async Task<Test> GetByIdAsync(int id)
    {
        return await _testRepository.FindByIdAsync(id);
    }
}