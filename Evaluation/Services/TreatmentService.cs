using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class TreatmentService : ITreatmentService
{
    private readonly ITreatmentRepository _treatmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TreatmentService(ITreatmentRepository treatmentRepository, IUnitOfWork unitOfWork)
    {
        _treatmentRepository = treatmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Treatment>> ListAsync()
    {
        return await _treatmentRepository.FindAllAsync();
    }

    public async Task<Treatment> GetByIdAsync(int id)
    {
        return await _treatmentRepository.FindByIdAsync(id);
    }

    public async Task<TreatmentResponse> SaveAsync(Treatment treatment)
    {
        try
        {
            await _treatmentRepository.AddAsync(treatment);
            await _unitOfWork.CompleteAsync();
            return new TreatmentResponse(treatment);
        }
        catch (Exception e)
        {
            return new TreatmentResponse("An error occurred while saving the treatment: " + e.Message);
        }
    }

    public async Task<TreatmentResponse> UpdateAsync(int id, Treatment treatment)
    {
        var existingTreatment = await _treatmentRepository.FindByIdAsync(id);
        if (existingTreatment == null)
            return new TreatmentResponse("Treatment not found.");
        
        existingTreatment.Counter = treatment.Counter;
        try
        {
            _treatmentRepository.Update(existingTreatment);
            await _unitOfWork.CompleteAsync();
            return new TreatmentResponse(existingTreatment);
        }
        catch (Exception e)
        {
            return new TreatmentResponse($"An error occurred while updating treatment: {e.Message}");
        }
    }

    public async Task<TreatmentResponse> DeleteAsync(int id)
    {
        var existingTreatment = await _treatmentRepository.FindByIdAsync(id);
        if (existingTreatment == null)
            return new TreatmentResponse("Treatment not found.");
        
        try
        {
            _treatmentRepository.Delete(existingTreatment);
            await _unitOfWork.CompleteAsync();
            return new TreatmentResponse(existingTreatment);
        }
        catch (Exception e)
        {
            return new TreatmentResponse($"An error occurred while deleting the treatment: {e.Message}");
        }
    }
}