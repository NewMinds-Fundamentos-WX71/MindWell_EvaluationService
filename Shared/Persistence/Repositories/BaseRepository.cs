using MindWell_EvaluationService.Shared.Persistence.Contexts;

namespace MindWell_EvaluationService.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}