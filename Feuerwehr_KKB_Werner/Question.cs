using System.Windows.Documents;

namespace Feuerwehr_KKB_Werner;

public class Question
{
    public string question { get; set; }
    public string category { get; set; }
    public List answers { get; set; }
    public int correctAnswer { get; set; }


    public Question(string q, string c, List a, int ca)
    {
        this.question = q;
        this.category = c;
        this.answers = a;
        this.correctAnswer = ca;
    }
}