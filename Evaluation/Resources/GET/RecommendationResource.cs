namespace MindWell_EvaluationService.Evaluation.Resources.GET;

public class RecommendationResource
{
    public int Id { get; set; }
    public int Frecuency { get; set; }
    public string Category { get; set; }
    public string Details { get; set; }

    public int Diagnose_Id { get; set; }
}