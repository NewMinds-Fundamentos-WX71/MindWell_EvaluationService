namespace MindWell_EvaluationService.Evaluation.Resources.POST;

public class CalculateAssessmentDiagnosis
{
    public int Assessment_Id { get; set; }
    public int[] Answers { get; set; }
}