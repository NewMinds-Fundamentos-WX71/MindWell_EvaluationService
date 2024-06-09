using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Contexts;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Persistence.Repositories;

public class TestRepository : BaseRepository, ITestRepository
{
    public TestRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Test>> FidnAllAsync()
    {
        return await _context.Tests.ToListAsync();
    }

    public async Task<Test> FindByIdAsync(int id)
    {
        return await _context.Tests
            .FindAsync(id);
    }
}