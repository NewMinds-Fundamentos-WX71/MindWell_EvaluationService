using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Contexts;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Persistence.Repositories;

public class AssessmentRecommendationRepository : BaseRepository, IAssessmentRecommendationRepository
{
    public AssessmentRecommendationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<AssessmentRecommendation>> FindAllAsync()
    {
        return await _context.AssessmentRecommendations.ToListAsync();
    }

    public async Task<IEnumerable<AssessmentRecommendation>> FindAllByAssessmentIdAsync(int id)
    {
        return await _context.AssessmentRecommendations
            .Where(ar => ar.Assessment_Id == id)
            .ToListAsync();
    }

    public async Task<IEnumerable<AssessmentRecommendation>> FindAllByRecommendationIdAsync(int id)
    {
        return await _context.AssessmentRecommendations
            .Where(ar => ar.Recommendation_Id == id)
            .ToListAsync();
    }

    public async Task<AssessmentRecommendation> FindByIdAsync(int id)
    {
        return await _context.AssessmentRecommendations
            .FindAsync(id);
    }

    public async Task AddAsync(AssessmentRecommendation assessmentRecommendation)
    {
        await _context.AssessmentRecommendations
            .AddAsync(assessmentRecommendation);
    }
}