using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Windows.Documents;

namespace Feuerwehr_KKB_Werner;

public class Question
{
    // if files are swapped, keys can be the same. key is not identifying
    // TODO: Delete key from json file and make question as identifying key
    public string key { get; set; }
    public string question { get; set; }
    public string category { get; set; }
    public string answer1 { get; set; }
    public string answer2 { get; set; }
    public string answer3 { get; set; }
    public int correctAnswer { get; set; }


    public Question(string k, string q, string c, string a1, string a2, string a3, int ca)
    {
        this.key = k;
        this.question = q;
        this.category = c;
        this.answer1 = a1;
        this.answer2 = a2;
        this.answer3 = a3;
        this.correctAnswer = ca;
    }
}