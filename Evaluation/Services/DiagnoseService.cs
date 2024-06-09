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

    public async Task<IEnumerable<Diagnosis>> ListAsync()
    {
        return await _diagnoseRepository.ListAsync();
    }

    public async Task<Diagnosis> GetByIdAsync(int id)
    {
        return await _diagnoseRepository.FindByIdAsync(id);
    }

    public async Task<DiagnosisResponse> SaveAsync(Diagnosis diagnosis)
    {
        try
        {
            await _diagnoseRepository.AddAsync(diagnosis);
            await _unitOfWork.CompleteAsync();
            return new DiagnosisResponse(diagnosis);
        }
        catch (Exception e)
        {
            return new DiagnosisResponse($"An error occurred while saving the diagnosis: {e.Message}");
        }
    }

    public async Task<DiagnosisResponse> UpdateAsync(int id, Diagnosis diagnosis)
    {
        try
        {
            var existingDiagnose = await _diagnoseRepository.FindByIdAsync(id);

            if (existingDiagnose == null)
                return new DiagnosisResponse("Diagnosis not found.");

            existingDiagnose.Name = diagnosis.Name;

            _diagnoseRepository.Update(existingDiagnose);
            await _unitOfWork.CompleteAsync();
            return new DiagnosisResponse(existingDiagnose);
        }
        catch (Exception e)
        {
            return new DiagnosisResponse($"An error occurred while updating the diagnosis: {e.Message}");
        }
    }

    public async Task<DiagnosisResponse> DeleteAsync(int id)
    {
        try
        {
            var existingDiagnose = await _diagnoseRepository.FindByIdAsync(id);

            if (existingDiagnose == null)
                return new DiagnosisResponse("Diagnosis not found.");

            _diagnoseRepository.Remove(existingDiagnose);
            await _unitOfWork.CompleteAsync();
            return new DiagnosisResponse(existingDiagnose);
        }
        catch (Exception e)
        {
            return new DiagnosisResponse($"An error occurred while deleting the diagnosis: {e.Message}");
        }
    }
}