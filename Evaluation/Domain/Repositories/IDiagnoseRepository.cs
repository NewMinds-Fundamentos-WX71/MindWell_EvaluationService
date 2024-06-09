using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface IDiagnoseRepository
{
    Task<IEnumerable<Diagnosis>> ListAsync();
    Task<Diagnosis> FindByIdAsync(int id);
    Task AddAsync(Diagnosis diagnosis);
    void Update(Diagnosis diagnosis);
    void Remove(Diagnosis diagnosis);
}