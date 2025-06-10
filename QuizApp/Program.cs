namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {




            #region Testing
            //Question question = new MultiAnswers();
            //Exam exam = new PracticeExam();


            //string? choice = default;
            //do
            //{
            //    Console.WriteLine("\n\n1.Press 'E' To Enter the Exam\n2.Press 'C' To Create new Exam\n3.Press 'Q' To Exit Exam ");

            //    Console.Write("\nEnter a value : ");
            //    choice = Console.ReadLine().ToLower().Trim();

            //    switch (choice)

            //    {
            //        case "e":
            //            if (exam.Questions.Count == 0) Console.WriteLine("\nSorry ,no Exam avail right now\n");
            //            else
            //                exam.StartExam();


            //            break;
            //        case "c":
            //            Console.WriteLine("Enter the number of Questions :");

            //            int numofQ = Convert.ToInt32(Console.ReadLine());

            //            exam.CreateExam(numofQ);

            //            Console.WriteLine("\n\nExam has been successfully Created\n");

            //            break;

            //        case "q":

            //            Console.WriteLine("\n\nGoodBye\n\n");

            //            break;
            //        default:
            //            Console.WriteLine("Unknown input ,Please try again");
            //            break;

            //    }






            //} while (choice != "q");
            //MultiAnswers question = new BoolQuestion();
            //Question create = question.CreateQuestion();
            //Console.WriteLine($"q:{create.QuestionHead} Correct:{create.IndexRightAnswer} degree:{create.Degree}");

            #endregion

            Teacher teacher = new Teacher();

            string? choice = "";

            do
            {
                Console.WriteLine("Choose Your View ");
                Console.WriteLine("\nFor Teacher View Press 'T'\nFor Student View Press 'S'\nTo Quit Press 'Q'");

                Console.Write("\nEnter your Choice: ");
                choice = Console.ReadLine()?.ToLower().Trim();

                switch (choice)
                {
                    case "t":
                        teacher.AddPracticalExam(); 
                        Console.WriteLine("Enter the number of Questions :");
                        if (int.TryParse(Console.ReadLine(), out int numOfQ))
                        {
                            teacher.Exams.Last().CreateExam(numOfQ);
                            Console.WriteLine("\nExam created successfully.\n");
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;

                    case "s":
                        if (teacher.Exams.Count == 0)
                        {
                            Console.WriteLine("There are no exams yet.\n");
                        }
                        else
                        {
                            Console.WriteLine("Available Exams:");
                            for (int i = 0; i < teacher.Exams.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {teacher.Exams[i].ExamTitle}");
                            }

                            Console.Write("\nChoose exam number: ");
                            if (int.TryParse(Console.ReadLine(), out int examIndex) && examIndex >= 1 && examIndex <= teacher.Exams.Count)

                            {
                                Exam selectedExam = teacher.Exams[examIndex - 1];
                                Student.StartNewExam(selectedExam);
                            }
                            else
                            {
                                Console.WriteLine("Invalid exam number.");
                            }
                        }
                        break;

                    case "q":
                        Console.WriteLine("\nGoodbye!");
                        break;

                    default:
                        Console.WriteLine("Unknown choice, try again.");
                        break;
                }

            } while (choice != "q");


        }
    }
}
