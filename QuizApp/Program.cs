namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Question question = new MultiAnswers();
            Exam exam = new PracticeExam();
            exam.CreateExam(1);
            exam.StartExam();



        }
    }
}
