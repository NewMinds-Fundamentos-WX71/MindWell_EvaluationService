namespace MindWell_EvaluationService.Evaluation.Resources.POST;

public class SaveRecommendationResource
{
    public int Frecuency { get; set; }
    public string Category { get; set; }
    public string Details { get; set; }

    public int Diagnose_Id { get; set; }
}