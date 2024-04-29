using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> ListAsync();
    Task<Question> FindByIdAsync(int id);
    Task AddAsync(Question question);
    void Update(Question question);
    void Remove(Question question);
}