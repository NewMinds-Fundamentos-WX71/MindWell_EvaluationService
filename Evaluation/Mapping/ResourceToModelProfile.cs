using AutoMapper;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Resources.POST;
using MindWell_EvaluationService.Evaluation.Resources.UPDATE;

namespace MindWell_EvaluationService.Evaluation.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAssessmentResource, Assessment>();
        CreateMap<SaveAssessmentRecommendationResource, AssessmentRecommendation>();
        CreateMap<SaveTreatmentResource, Treatment>();
        CreateMap<UpdateAssessmentResource, Assessment>();
        CreateMap<UpdateTreatmentResource, Treatment>();
    }
}