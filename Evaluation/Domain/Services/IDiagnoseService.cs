using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IDiagnoseService
{
    Task<IEnumerable<Diagnosis>> ListAsync();
    Task<Diagnosis> GetByIdAsync(int id);
}