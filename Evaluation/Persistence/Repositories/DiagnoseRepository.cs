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

    public async Task<IEnumerable<Diagnose>> ListAsync()
    {
        return await _context.Diagnoses.ToListAsync();
    }

    public async Task<Diagnose> FindByIdAsync(int id)
    {
        return await _context.Diagnoses.FindAsync(id);
    }

    public async Task AddAsync(Diagnose diagnose)
    {
        await _context.Diagnoses.AddAsync(diagnose);
    }

    public void Update(Diagnose diagnose)
    {
        _context.Update(diagnose);
    }

    public void Remove(Diagnose diagnose)
    {
        _context.Diagnoses.Remove(diagnose);
    }
}