using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace Feuerwehr_KKB_Werner;

public partial class Quiz : Page
{
    
    AllQuestions currentQuestionSession{ get; set; }
    public Quiz( AllQuestions aQ)
    {
        InitializeComponent();
        this.currentQuestionSession = aQ;
        cmbCategory.ItemsSource = this.currentQuestionSession.allCategorys;



        cmbCategory.SelectedItem = this.currentQuestionSession.currentCategory;
        
        
    }
    private void goToUebersicht(object sender, RoutedEventArgs e)
    {
        //NavigationService.GoBack();
        this.NavigationService.Navigate(new Uri($"Uebersicht.xaml", UriKind.Relative));
    }
    
    private void goToStartQuiz(object sender, RoutedEventArgs e)
    {
        if (this.currentQuestionSession.currentCategory != "")
        {
            NavigationService.Navigate(new AddQuestion(this.currentQuestionSession));
        }
        else
        {
            MessageBox.Show("Bitte wähle eine Kategorie aus!");
        }
    }
    
    private void cmbCategory_SelectionChanged(object sender,
        System.Windows.Controls.SelectionChangedEventArgs e)
    {
        string content = cmbCategory.SelectedItem.ToString();
        this.currentQuestionSession.currentCategory = content;
    }
    
}