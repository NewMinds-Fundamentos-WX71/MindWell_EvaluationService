using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Contexts;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Persistence.Repositories;

public class QuestionRepository : BaseRepository, IQuestionRepository
{
    public QuestionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Question>> ListAsync()
    {
        return await _context.Questions.ToListAsync();
    }

    public async Task<Question> FindByIdAsync(int id)
    {
        return await _context.Questions.FindAsync(id);
    }

    public async Task<IEnumerable<Question>> FindByTestIdAsync(int id)
    {
        return await _context.Questions
            .Where(q => q.Test_Id == id)
            .ToListAsync();
    }
}