namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Assessment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int User_Id { get; set; }
    
    public int Diagnose_Id { get; set; }
    public Diagnose Diagnose { get; set; }
    public IList<AssessmentQuestion> AssessmentQuestions { get; set; }
}