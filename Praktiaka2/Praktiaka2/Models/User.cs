namespace Praktiaka2.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }           // Текст питання
        public string CorrectAnswer { get; set; }  // Правильна відповідь
        public string Category { get; set; }       // Наприклад: Орфографія, Пунктуація
        public int Difficulty { get; set; }        // Складність від 1 до 5
    }
}