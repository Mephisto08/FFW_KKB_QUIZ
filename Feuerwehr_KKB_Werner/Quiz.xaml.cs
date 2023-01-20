using System.Windows.Controls;
using System.Windows;

namespace Feuerwehr_KKB_Werner;

public partial class Quiz : Page
{
    public Quiz()
    {
        InitializeComponent();
    }
    private void goToUebersicht(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}