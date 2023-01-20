using System.Windows.Controls;
using System.Windows;


namespace Feuerwehr_KKB_Werner;

public partial class Uebersicht : Page
{
    public Uebersicht()
    {
        InitializeComponent();
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Quiz());
    }
}