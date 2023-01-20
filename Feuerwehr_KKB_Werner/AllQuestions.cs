using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Feuerwehr_KKB_Werner;

public class AllQuestions
{

    public List<Question> questions{ get; set; }
    
    public AllQuestions()
    {
        this.readQuestions();
    }

    private void readQuestions()
    {
        // TODO: Relativen Pfad einbauen
        string jsonFilePath = "C:\\Users\\werne\\OneDrive\\FFW_KKB\\Projekte\\FFW_KKB_QUIZ\\Feuerwehr_KKB_Werner\\Resources\\questions\\Fragen_2.json";
            
        string text = File.ReadAllText(jsonFilePath);
        
        var person = JsonSerializer.Deserialize<Question>(text);
        
        Console.WriteLine($"First name: {person.question}");

    }
}