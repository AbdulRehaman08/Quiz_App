namespace Quizz.Model
{
    public class QuestionModel
    {
       public int Id { get; set; }

        public string QuestionName { get; set; }

        public string Answer_1 { get; set; }

        public string Answer_2 { get; set; }

        public string Answer_3 { get; set; }

        public string Answer_4 { get; set; }

        public string CorrectAnswer { get; set; }
        
    }
}