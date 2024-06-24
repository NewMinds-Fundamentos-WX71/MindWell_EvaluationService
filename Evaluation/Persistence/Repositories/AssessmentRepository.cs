using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Contexts;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Persistence.Repositories;

public class AssessmentRepository : BaseRepository, IAssessmentRepository
{
    public AssessmentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Assessment>> ListAsync()
    {
        return await _context.Assessments.ToListAsync();
    }

    public async Task<Assessment> FindByIdAsync(int id)
    {
        return await _context.Assessments.FindAsync(id);
    }

    public async Task<IEnumerable<Assessment>> ListByPatientIdAsync(int id)
    {
        return await _context.Assessments
            .Where(x => x.User_Id == id)
            .ToListAsync();
    }

    public async Task AddAsync(Assessment assessment)
    {
        await _context.Assessments.AddAsync(assessment);
    }

    public void Update(Assessment assessment)
    {
        _context.Update(assessment);
    }

    public void Remove(Assessment assessment)
    {
        _context.Assessments.Remove(assessment);
    }
}