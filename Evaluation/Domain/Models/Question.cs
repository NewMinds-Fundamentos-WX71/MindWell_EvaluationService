namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    
    public IList<AssessmentQuestion> AssessmentQuestions { get; set; }
}