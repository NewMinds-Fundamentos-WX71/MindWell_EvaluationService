namespace MindWell_EvaluationService.Evaluation.Resources.GET;

public class RecommendationResource
{
    public int Id { get; set; }
    public string Frecuency { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public int Lifespan { get; set; }
    public int Diagnosis_Id { get; set; }
}