using System;
using System.Windows.Controls;
using System.Windows;


namespace Feuerwehr_KKB_Werner;

public partial class Uebersicht : Page
{
    AllQuestions currentQuestionSession{ get; set; }
    public Uebersicht()
    { 
        InitializeComponent();
        this.currentQuestionSession = new AllQuestions();
    }
    
    // 
    private void goToQuiz(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Quiz(this.currentQuestionSession));
    }
    
    // 
    private void goToAddQuestion(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new AddQuestion(this.currentQuestionSession));
    }
    
    //
    private void goToExportQuiz(object sender, RoutedEventArgs e)
    {
        //NavigationService.Navigate(new Quiz());
        string content = "WIP";
        if (content != null)
            MessageBox.Show(content);
    }
}