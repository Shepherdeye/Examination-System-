namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            //Question question = new MultiAnswers();
            Question question = new BoolQuestion();
            question.CreateQuestion(2);

        }
    }
}
