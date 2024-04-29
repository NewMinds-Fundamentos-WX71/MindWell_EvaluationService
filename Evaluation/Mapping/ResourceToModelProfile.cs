using AutoMapper;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Resources.POST;

namespace MindWell_EvaluationService.Evaluation.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAssessmentResource, Assessment>();
        CreateMap<SaveAssessmentQuestionResource, AssessmentQuestion>();
        CreateMap<SaveDiagnoseResource, Diagnose>();
        CreateMap<SaveQuestionResource, Question>();
        CreateMap<SaveRecommendationResource, Recommendation>();
    }
}