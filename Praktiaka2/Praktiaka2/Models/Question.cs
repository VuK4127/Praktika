namespace Praktiaka2.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }           // Саме питання
        public string CorrectAnswer { get; set; }  // Правильна відповідь
        public string Category { get; set; }       // Категорія
        public int Difficulty { get; set; }        // Складність (1-5)
    }
}