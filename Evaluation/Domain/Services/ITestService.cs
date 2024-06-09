using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface ITestService
{
    Task<IEnumerable<Test>> ListAsync();
    Task<Test> GetByIdAsync(int id);
}