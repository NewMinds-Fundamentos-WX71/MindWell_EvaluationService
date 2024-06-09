namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Recommendation
{
    public int Id { get; set; }
    public string Frecuency { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public int Lifespan { get; set; }
    
    public int Diagnosis_Id { get; set; }
    public Diagnosis Diagnosis { get; set; }
    public List<AssessmentRecommendation> AssessmentRecomendations { get; set; }
}