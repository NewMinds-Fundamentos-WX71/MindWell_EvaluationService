using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface ITestRepository
{
    Task<IEnumerable<Test>> FidnAllAsync();
    Task<Test> FindByIdAsync(int id);
}