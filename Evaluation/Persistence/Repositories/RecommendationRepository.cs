using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Contexts;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Persistence.Repositories;

public class RecommendationRepository : BaseRepository, IRecommendationRepository
{
    public RecommendationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Recommendation>> ListAsync()
    {
        return await _context.Recommendations.ToListAsync();
    }

    public async Task<Recommendation> FindByIdAsync(int id)
    {
        return await _context.Recommendations.FindAsync(id);
    }

    public async Task<IEnumerable<Recommendation>> FindAllByDiagnosisIdAsync(int id)
    {
        return await _context.Recommendations
            .Where(r => r.Diagnosis_Id == id)
            .ToListAsync();
    }
}