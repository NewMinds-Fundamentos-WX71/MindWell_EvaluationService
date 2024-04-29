using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Contexts;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Persistence.Repositories;

public class AssessmentQuestionRepository : BaseRepository, IAssessmentQuestionRepository
{
    public AssessmentQuestionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<AssessmentQuestion>> ListAsync()
    {
        return await _context.AssessmentQuestions.ToListAsync();
    }

    public async Task<AssessmentQuestion> FindByIdAsync(int id)
    {
        return await _context.AssessmentQuestions.FindAsync(id);
    }

    public async Task AddAsync(AssessmentQuestion assessmentQuestion)
    {
        await _context.AssessmentQuestions.AddAsync(assessmentQuestion);
    }

    public void Update(AssessmentQuestion assessmentQuestion)
    {
        _context.Update(assessmentQuestion);
    }

    public void Remove(AssessmentQuestion assessmentQuestion)
    {
        _context.AssessmentQuestions.Remove(assessmentQuestion);
    }
}