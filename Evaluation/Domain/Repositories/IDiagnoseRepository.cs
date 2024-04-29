using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface IDiagnoseRepository
{
    Task<IEnumerable<Diagnose>> ListAsync();
    Task<Diagnose> FindByIdAsync(int id);
    Task AddAsync(Diagnose diagnose);
    void Update(Diagnose diagnose);
    void Remove(Diagnose diagnose);
}