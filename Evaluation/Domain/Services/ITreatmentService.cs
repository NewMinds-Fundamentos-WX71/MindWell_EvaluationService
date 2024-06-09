using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface ITreatmentService
{
    Task<IEnumerable<Treatment>> ListAsync();
    Task<Treatment> GetByIdAsync(int id);
    Task<TreatmentResponse> SaveAsync(Treatment treatment);
    Task<TreatmentResponse> UpdateAsync(int id, Treatment treatment);
    Task<TreatmentResponse> DeleteAsync(int id);
}