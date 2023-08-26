namespace X.Kwiz.Api.Entities;
public class QuestionOption
{
    public string Content {get;set;}
    public bool IsCorrect {get;set;}
    public bool IsRequired {get;set;}
    public string Explanation {get;set;}
}