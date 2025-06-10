using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{

    abstract internal class Exam
    {
        public DateTime ExamDate { get; protected set; } = DateTime.Now;
        public string ExamTitle { get; protected set; } = "Unknown Exam";
        public List<Question> Questions { get; protected set; } = new();
        public double Score { get; protected set; }

        public abstract List<Question> CreateExam(int numberOfQuestions);

        public abstract void StartExam();
        public override string ToString()
        {
            return $"ExamTitle:{ExamTitle}\nDate:{this.ExamDate}\nQuestionsCount :{Questions.Count}";
        }

    }

    class PracticeExam : Exam
    {
        public override List<Question> CreateExam(int numberOfQuestions)
        {
            Console.WriteLine("Enter The title of Exam");
            string? input = "";

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("invalid,enter a value");
                }


            } while (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input));

            ExamTitle = input;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"\nEnter the type of Question:\n1. Multi Choice\n2. True Or False");


                int qChoice = Convert.ToInt32(Console.ReadLine());

                if (qChoice != 1 && qChoice != 2)
                {
                    Console.WriteLine("Invalid choice, please enter 1 or 2.");
                    i--;
                    continue;
                }

                if (qChoice == 1)
                {
                    Question question = new MultiAnswers().CreateQuestion();
                    this.Questions.Add(question);
                }
                else
                {
                    Question question = new BoolQuestion().CreateQuestion();
                    this.Questions.Add(question);
                }




            }
            //this.Questions.AddRange(exam);

            return Questions;
        }

        public override void StartExam()
        {
            List<string> typedAnswers = new List<string>();

            double total = default;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n\nExam Name:{ExamTitle}\nExam Date:{ExamDate}");
            Console.ForegroundColor = ConsoleColor.White;

            int answer = default;
            string? input = default;
            for (int i = 0; i < this.Questions.Count; i++)
            {
                total += Questions[i].Degree;

                Console.WriteLine($"Q{i + 1} of {Questions.Count}");
                Console.WriteLine($"Q{i + 1}:{Questions[i].QuestionHead}?");
                for (int j = 0; j < Questions[i].Answers.Count; j++)
                {
                    Console.WriteLine($"{j + 1}.{Questions[i].Answers[j]}");

                }


                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input");
                    i--;
                    continue;
                }

                 answer = Convert.ToInt32(input);

                if (answer - 1 == Questions[i].IndexRightAnswer)
                {
                    Score += Questions[i].Degree;
                    typedAnswers.Add($"{i + 1}.{this.Questions[i].Answers[answer - 1]}=> Correct");
                }
                else
                {

                    typedAnswers.Add($"{i + 1}.{this.Questions[i].Answers[answer - 1]}=> Wrong");
                }
            }
            if (Score < total / 2)
                Console.WriteLine($"Failed, you get {Score} from {total}\n");
            else
                Console.WriteLine($"Congratulation, you get {Score} from {total}\n");

            
            Console.WriteLine($"Check your Answers\n\n{String.Join(",\n", typedAnswers)}");

        }

    }


}
