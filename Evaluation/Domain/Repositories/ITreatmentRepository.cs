using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface ITreatmentRepository
{
    Task<IEnumerable<Treatment>> FindAllAsync();
    Task<Treatment> FindByIdAsync(int id);
    Task AddAsync(Treatment treatment);
    void Update(Treatment treatment);
    void Delete(Treatment treatment);
}