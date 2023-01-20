using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        cmbCategory.SelectedItem = this.currentQuestionSession.allCategorys.ElementAt(0);
        this.currentQuestionSession.currentCategory = this.currentQuestionSession.allCategorys.ElementAt(0);
        
        
    }
    private void goToUebersicht(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
    
    private void goToStartQuiz(object sender, RoutedEventArgs e)
    {
        if (this.currentQuestionSession.currentCategory != "")
        {
            NavigationService.Navigate(new CurrentQuestion(this.currentQuestionSession));
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