using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Evaluation.Persistence.Repositories;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class DiagnoseService : IDiagnoseService
{
    private readonly IDiagnoseRepository _diagnoseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DiagnoseService(IDiagnoseRepository diagnoseRepository, IUnitOfWork unitOfWork)
    {
        _diagnoseRepository = diagnoseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Diagnose>> ListAsync()
    {
        return await _diagnoseRepository.ListAsync();
    }

    public async Task<Diagnose> GetByIdAsync(int id)
    {
        return await _diagnoseRepository.FindByIdAsync(id);
    }

    public async Task<DiagnoseResponse> SaveAsync(Diagnose diagnose)
    {
        try
        {
            await _diagnoseRepository.AddAsync(diagnose);
            await _unitOfWork.CompleteAsync();
            return new DiagnoseResponse(diagnose);
        }
        catch (Exception e)
        {
            return new DiagnoseResponse($"An error occurred while saving the diagnose: {e.Message}");
        }
    }

    public async Task<DiagnoseResponse> UpdateAsync(int id, Diagnose diagnose)
    {
        try
        {
            var existingDiagnose = await _diagnoseRepository.FindByIdAsync(id);

            if (existingDiagnose == null)
                return new DiagnoseResponse("Diagnose not found.");

            existingDiagnose.Result = diagnose.Result;

            _diagnoseRepository.Update(existingDiagnose);
            await _unitOfWork.CompleteAsync();
            return new DiagnoseResponse(existingDiagnose);
        }
        catch (Exception e)
        {
            return new DiagnoseResponse($"An error occurred while updating the diagnose: {e.Message}");
        }
    }

    public async Task<DiagnoseResponse> DeleteAsync(int id)
    {
        try
        {
            var existingDiagnose = await _diagnoseRepository.FindByIdAsync(id);

            if (existingDiagnose == null)
                return new DiagnoseResponse("Diagnose not found.");

            _diagnoseRepository.Remove(existingDiagnose);
            await _unitOfWork.CompleteAsync();
            return new DiagnoseResponse(existingDiagnose);
        }
        catch (Exception e)
        {
            return new DiagnoseResponse($"An error occurred while deleting the diagnose: {e.Message}");
        }
    }
}