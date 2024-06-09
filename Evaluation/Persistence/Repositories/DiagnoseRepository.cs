using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Contexts;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Persistence.Repositories;

public class DiagnoseRepository : BaseRepository, IDiagnoseRepository
{
    public DiagnoseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Diagnosis>> ListAsync()
    {
        return await _context.Diagnosis.ToListAsync();
    }

    public async Task<Diagnosis> FindByIdAsync(int id)
    {
        return await _context.Diagnosis.FindAsync(id);
    }

    public async Task AddAsync(Diagnosis diagnosis)
    {
        await _context.Diagnosis.AddAsync(diagnosis);
    }

    public void Update(Diagnosis diagnosis)
    {
        _context.Update(diagnosis);
    }

    public void Remove(Diagnosis diagnosis)
    {
        _context.Diagnosis.Remove(diagnosis);
    }
}