using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Feuerwehr_KKB_Werner;

public class AllQuestions
{

    public List<Question> questions { get; set; } = new List<Question>();
    public HashSet<string> allCategorys{ get; set; } = new HashSet<string>();

    public string currentCategory { get; set; } = "";
    public AllQuestions()
    {
        this.readQuestions();
    }

    private void calcAllCategorys()
    {
        foreach(Question q in questions)
        {
            allCategorys.Add(q.category);
        }
    }
    
    private void readQuestions()
    
    {
        List<Question> items;
        using (StreamReader r = new StreamReader(@"./Resources/questions/AlleFragen.json"))
        {
            
            string json = r.ReadToEnd();
            this.questions = JsonConvert.DeserializeObject<List<Question>>(json);
        }
        calcAllCategorys();
    }
}