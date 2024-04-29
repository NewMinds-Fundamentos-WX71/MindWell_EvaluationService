using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IDiagnoseService
{
    Task<IEnumerable<Diagnose>> ListAsync();
    Task<Diagnose> GetByIdAsync(int id);
    Task<DiagnoseResponse> SaveAsync(Diagnose diagnose);
    Task<DiagnoseResponse> UpdateAsync(int id, Diagnose diagnose);
    Task<DiagnoseResponse> DeleteAsync(int id);
}