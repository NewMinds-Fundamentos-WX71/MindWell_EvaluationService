using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> ListAsync();
    Task<Question> FindByIdAsync(int id);
    Task<IEnumerable<Question>> FindByTestIdAsync(int id);
}