using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Newtonsoft.Json;

namespace Feuerwehr_KKB_Werner;


public partial class AddQuestion : Page
{
    private string newQuestion = "";
    private string newAnswer1 = "";
    private string newAnswer2 = "";
    private string newAnswer3 = "";
    private string newCategory = "";
    private int newCorrectAnswer= -1;
    AllQuestions currentQuestionSession{ get; set; }
    
    public AddQuestion( AllQuestions aQ)
    {
        InitializeComponent();
        this.currentQuestionSession = aQ;
    }
    
    private void goToUebersicht(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
    
    private void onClick_SafeQuestion(object sender, RoutedEventArgs e){
        // check if all values of input fields are correct
        if (newQuestion != "" && newAnswer1 != "" && newAnswer2 != "" && newAnswer3 != "" && newCategory != "" &&
            newCorrectAnswer != -1){


            // get last element of all questions and increase by 1
            string newIdOfQuestion = (Int32.Parse(this.currentQuestionSession.questions[^1].key) + 1).ToString();
            
            Question newQuestion = new Question(newIdOfQuestion, this.newQuestion, this.newCategory, this.newAnswer1, this.newAnswer2,
                this.newAnswer3, this.newCorrectAnswer);
            this.currentQuestionSession.questions.Add(newQuestion);

            string json = JsonConvert.SerializeObject(this.currentQuestionSession.questions.ToArray());
            //write string to file
            System.IO.File.WriteAllText(@"./Resources/questions/AlleFragen.json", json);
            
            MessageBox.Show("Frage wurde erfolgreich hinzugefügt!", "Yippie", MessageBoxButton.OK, MessageBoxImage.Information);
            
            // after safed question clear all textboxes
            AddQuestion_TextBox.Text = "";
            AddAnswer1_TextBox.Text = "";
            AddAnswer2_TextBox.Text = "";
            AddAnswer3_TextBox.Text = "";
            AddCategory_TextBox.Text = "Kleinlöschgeräte";
            
            // disable background for all answers
            AddAnswer1_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
            AddAnswer2_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
            AddAnswer3_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
        }
        else{
            MessageBox.Show("Bitte fülle alle Felder aus!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        

    }
    
    private void onClick_AddAnswer1(object sender, MouseButtonEventArgs e)
    {
        // set background + currentAnswer
        AddAnswer1_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
        this.newCorrectAnswer = 0;
        
        // disable background for other answers
        AddAnswer2_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
        AddAnswer3_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
    }
    
    private void onClick_AddAnswer2(object sender, MouseButtonEventArgs e)
    {
        // set background + currentAnswer
        AddAnswer2_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
        this.newCorrectAnswer = 1;
        
        // disable background for other answers
        AddAnswer1_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
        AddAnswer3_TextBlock.Background = new SolidColorBrush(Colors.Transparent);

    }
    
    private void onClick_AddAnswer3(object sender, MouseButtonEventArgs e)
    {
        // set background + currentAnswer
        AddAnswer3_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
        this.newCorrectAnswer = 2;
        
        // disable background for other answers
        AddAnswer1_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
        AddAnswer2_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
           
    }

    private void onChange_AddQuestion(object sender, EventArgs e)
    {
        this.newQuestion = AddQuestion_TextBox.Text.ToString();
    }
    
    private void onChange_AddAnswer1(object sender, EventArgs e)
    {
        this.newAnswer1 = AddAnswer1_TextBox.Text.ToString();
    }
    
    private void onChange_AddAnswer2(object sender, EventArgs e)
    {
        this.newAnswer2 = AddAnswer2_TextBox.Text.ToString();
    }
    
    private void onChange_AddAnswer3(object sender, EventArgs e)
    {
        this.newAnswer3 = AddAnswer3_TextBox.Text.ToString();
    }
    
    private void onChange_AddCategory(object sender, EventArgs e)
    {
        this.newCategory = AddCategory_TextBox.Text.ToString();
    }
    
    
    
}