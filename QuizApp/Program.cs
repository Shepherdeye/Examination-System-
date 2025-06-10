namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Question question = new MultiAnswers();
            Exam exam = new PracticeExam();
            exam.CreateExam(5);
            exam.StartExam();

            //MultiAnswers question = new BoolQuestion();
            //Question create = question.CreateQuestion();
            //Console.WriteLine($"q:{create.QuestionHead} Correct:{create.IndexRightAnswer} degree:{create.Degree}");



        }
    }
}
