using System.Windows;
using System.Windows.Controls;

namespace Feuerwehr_KKB_Werner;

public partial class AddQuestion : Page
{
    public AddQuestion()
    {
        InitializeComponent();
    }
    
    private void goToUebersicht(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}