using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Feuerwehr_KKB_Werner;

public partial class CurrentQuestion : Page
{
    AllQuestions currentQuestionSession{ get; set; }
    List<Question> currentQuestionsFromCategory{ get; set; } = new List<Question>();

    private int indexQuestionList = 0;
    private int selectedAnswer = -1;
    public CurrentQuestion(AllQuestions aQ)
    {
        InitializeComponent();
        this.currentQuestionSession = aQ;
        getAllQuestionsFromCategory();
        Question_TextBlock.Text = currentQuestionsFromCategory[indexQuestionList].question;
        Answer1_TextBlock.Text = "a)   " + currentQuestionsFromCategory[indexQuestionList].answer1;
        Answer2_TextBlock.Text = "b)   " + currentQuestionsFromCategory[indexQuestionList].answer2;
        Answer3_TextBlock.Text = "c)   " + currentQuestionsFromCategory[indexQuestionList].answer3;
    }
    
    private void goToQuiz(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void checkAnswer()
    {
        // get current question
        Question currentQuestion = this.currentQuestionsFromCategory[this.indexQuestionList];
        
        // check if selected answer is correct
        if (currentQuestion.correctAnswer == selectedAnswer)
        {
            QuestionBackground_Border.Background = new SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
            QuestionBackground_Border.Opacity = 0.3;
        }
        // wrong Answer
        else
        {
            QuestionBackground_Border.Background = new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
            QuestionBackground_Border.Opacity = 0.3;
        }
        switch (currentQuestion.correctAnswer)
        {
            case 0:
                Answer1_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
                Answer2_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
                Answer3_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
                break;
            case 1:
                Answer1_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
                Answer2_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
                Answer3_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
                break;
            case 2:
                Answer1_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
                Answer2_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
                Answer3_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
                break;
            default:
                break;
        }
    }
    
    private void onClick_checkAnswer(object sender, RoutedEventArgs e)
    {
        // check mode of button
        if (CheckAnswer_Button.Content.ToString() == "Prüfen!")
        {
            // check if any answer is selected
            if (selectedAnswer != -1)
            {
                checkAnswer();
                CheckAnswer_Button.Content = "Weiter";
            }
        }
        else if (CheckAnswer_Button.Content.ToString() == "Weiter")
        {
            // update Index of Question
            indexQuestionList += 1;
            
            // check if all question from category have been answered
            if (indexQuestionList == this.currentQuestionsFromCategory.Count)
            {

                MessageBox.Show(
                    "Alle Fragen der ausgewählten Kategorie wurden beantwortet.\nDu kehrst nun zur Kategorie auswahl zurück.",
                    "Geschafft!");
                NavigationService.GoBack();
            } 
            else{
                // disable background for answers
                Answer1_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
                Answer2_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
                Answer3_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
            
                // reset background
                QuestionBackground_Border.Background = new SolidColorBrush(Color.FromRgb(166, 166, 166));
                QuestionBackground_Border.Opacity = 0.8;
            
                // update content from page
                Question_TextBlock.Text = currentQuestionsFromCategory[indexQuestionList].question;
                Answer1_TextBlock.Text = "a)   " + currentQuestionsFromCategory[indexQuestionList].answer1;
                Answer2_TextBlock.Text = "b)   " +currentQuestionsFromCategory[indexQuestionList].answer2;
                Answer3_TextBlock.Text = "c)   " + currentQuestionsFromCategory[indexQuestionList].answer3;
            
                // update Button
                CheckAnswer_Button.Content = "Prüfen!";
            
                // reset currenAnswer
                selectedAnswer = -1;
            }
            
            
        }

    }

    private void getAllQuestionsFromCategory()
    {
        foreach(Question q in currentQuestionSession.questions)
        {
            if (q.category == currentQuestionSession.currentCategory)
            {
                currentQuestionsFromCategory.Add(q);
            }
        }
    }
    
    private void onClick_Answer1(object sender, MouseButtonEventArgs e)
    {
        // set background + currentAnswer
        Answer1_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 255, 253));
        this.selectedAnswer = 0;
        
        // disable background for other answers
        Answer2_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
        Answer3_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
    }
    
    private void onClick_Answer2(object sender, MouseButtonEventArgs e)
    {
        // set background + currentAnswer
        Answer2_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 255, 253));
        this.selectedAnswer = 1;
        
        // disable background for other answers
        Answer1_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
        Answer3_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
    }
    
    private void onClick_Answer3(object sender, MouseButtonEventArgs e)
    {
        // set background + currentAnswer
        Answer3_TextBlock.Background = new SolidColorBrush(Color.FromArgb(127, 255, 255, 253));
        this.selectedAnswer = 2;
        
        // disable background for other answers
        Answer1_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
        Answer2_TextBlock.Background = new SolidColorBrush(Colors.Transparent);
    }
    
}