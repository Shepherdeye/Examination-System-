namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Question question = new MultiAnswers();
            Exam exam = new PracticeExam();


            string? choice = default;
            do
            {
                Console.WriteLine("\n\n1.Press 'E' To Enter the Exam\n2.Press 'C' To Create new Exam\n3.Press 'Q' To Exit Exam ");

                Console.Write("\nEnter a value : ");
                choice = Console.ReadLine().ToLower().Trim();

                switch (choice)

                {
                    case "e":
                        if (exam.Questions.Count == 0) Console.WriteLine("\nSorry ,no Exam avail right now\n");
                        else
                            exam.StartExam();


                        break;
                    case "c":
                        Console.WriteLine("Enter the number of Questions :");

                        int numofQ = Convert.ToInt32(Console.ReadLine());

                        exam.CreateExam(numofQ);

                        Console.WriteLine("\n\nExam has been successfully Created\n");

                        break;

                    case "q":

                        Console.WriteLine("\n\nGoodBye\n\n");

                        break;
                    default:
                        Console.WriteLine("Unknown input ,Please try again");
                        break;

                }






            } while (choice != "q");
            //MultiAnswers question = new BoolQuestion();
            //Question create = question.CreateQuestion();
            //Console.WriteLine($"q:{create.QuestionHead} Correct:{create.IndexRightAnswer} degree:{create.Degree}");



        }
    }
}
