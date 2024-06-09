using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Contexts;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Persistence.Repositories;

public class TreatmentRepository : BaseRepository, ITreatmentRepository
{
    public TreatmentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Treatment>> FindAllAsync()
    {
        return await _context.Treatments.ToListAsync();
    }

    public async Task<Treatment> FindByIdAsync(int id)
    {
        return await _context.Treatments.FindAsync(id);
    }

    public async Task AddAsync(Treatment treatment)
    {
        await _context.Treatments.AddAsync(treatment);
    }

    public void Update(Treatment treatment)
    {
        _context.Update(treatment);
    }

    public void Delete(Treatment treatment)
    {
        _context.Treatments.Remove(treatment);
    }
}