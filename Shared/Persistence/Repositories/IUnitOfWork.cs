namespace MindWell_EvaluationService.Shared.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}