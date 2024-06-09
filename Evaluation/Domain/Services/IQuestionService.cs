using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IQuestionService
{
    Task<IEnumerable<Question>> ListAsync();
    Task<Question> GetByIdAsync(int id);
    Task<IEnumerable<Question>> ListByTestIdAsync(int id);
}