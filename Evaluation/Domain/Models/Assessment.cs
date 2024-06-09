namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Assessment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int User_Id { get; set; }
    
    public int Diagnosis_Id { get; set; }
    public Diagnosis Diagnosis { get; set; }
    public List<AssessmentRecommendation> AssessmentRecommendations { get; set; }
    public Treatment Treatment { get; set; }
}