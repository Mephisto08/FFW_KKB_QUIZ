using System.Windows;
using System.Windows.Controls;

namespace Feuerwehr_KKB_Werner;

public partial class AddQuestion : Page
{
    AllQuestions currentQuestionSession{ get; set; }
    public AddQuestion(AllQuestions aQ)
    {
        this.currentQuestionSession = aQ;
        InitializeComponent();
        MessageBox.Show(this.currentQuestionSession.currentCategory);
    }
    
    private void goToQuiz(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}