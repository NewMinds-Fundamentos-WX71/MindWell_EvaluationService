namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Recommendation
{
    public int Id { get; set; }
    public int Frecuency { get; set; }
    public string Category { get; set; }
    public string Details { get; set; }
    
    public int Diagnose_Id { get; set; }
    public Diagnose Diagnose { get; set; }
}