private void Submit_Click(object sender, System.Windows.RoutedEventArgs e)
{
    if (AnswerInput.Text.ToLower() == "прекрасний") // Тимчасова перевірка
    {
        ResultText.Text = "Правильно! Молодець!";
        ResultText.Foreground = System.Windows.Media.Brushes.Green;
    }
    else
    {
        ResultText.Text = "Спробуй ще раз.";
        ResultText.Foreground = System.Windows.Media.Brushes.Red;
    }
}