using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface IAssessmentRepository
{
    Task<IEnumerable<Assessment>> ListAsync();
    Task<Assessment> FindByIdAsync(int id);
    Task AddAsync(Assessment assessment);
    void Update(Assessment assessment);
    void Remove(Assessment assessment);
}