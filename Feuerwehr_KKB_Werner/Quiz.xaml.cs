using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace Feuerwehr_KKB_Werner;

public partial class Quiz : Page
{
    private List<String> testColor = new List<string>() { "string1", "string2", "string3", "string4" };
    public Quiz()
    {
        InitializeComponent();
        AllQuestions questions = new AllQuestions();
        
        //cmbColors.ItemsSource = this.testColor;
    }
    private void goToUebersicht(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
    
}