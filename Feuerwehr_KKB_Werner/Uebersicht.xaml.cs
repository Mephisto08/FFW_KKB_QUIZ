using System.Windows.Controls;
using System.Windows;


namespace Feuerwehr_KKB_Werner;

public partial class Uebersicht : Page
{
    public Uebersicht()
    {
        InitializeComponent();
    }
    private void goToQuiz(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Quiz());
    }
}