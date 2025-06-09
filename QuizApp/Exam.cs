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
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public string ExamTitle { get; set; } = "Unknown Exam";
        public List<Question> Questions { get; set; } = new();
        public double Score { get; protected set; }

        public abstract List<Question> CreateExam(int numberOfQuestions);

        public abstract void StartExam();
        public override string ToString()
        {
            return $"Date:{this.ExamDate} QuestionsCount :{Questions.Count}";
        }

    }

    class PracticeExam : Exam
    {
        public override List<Question> CreateExam(int numberOfQuestions)
        {
            Console.WriteLine("Enter The title of Exam");
            ExamTitle = Console.ReadLine();
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

            Console.WriteLine($"Exam Name:{ExamTitle}\nExam Date:{ExamDate}");

            int answer = default;

            for (int i = 0; i < this.Questions.Count; i++)
            {
                total += Questions[i].Degree;
                Console.WriteLine($"Q{i + 1} of {Questions.Count}");
                Console.WriteLine($"Q{i + 1}:{Questions[i].QuestionHead}?");
                for (int j = 0; j < Questions[i].Answers.Count; j++)
                {
                    Console.WriteLine($"{j + 1}.{Questions[i].Answers[j]}");

                }

                answer = Convert.ToInt32(Console.ReadLine());

                if (answer - 1 == Questions[i].IndexRightAnswer)
                {
                    Score += Questions[i].Degree;
                    typedAnswers.Add($"{i + 1}.{this.Questions[i].Answers[answer-1]}=>correct");

                }
                else
                {

                    typedAnswers.Add($"{i + 1}.{this.Questions[i].Answers[answer-1]}=>Wrong");
                }


            }
            if (Score < total / 2)
                Console.WriteLine($"Failed, you get {Score} from {total}\n");
            else
                Console.WriteLine($"Congratulation, you get {Score} from {total}\n");


            Console.WriteLine($"Check your Answers\n{String.Join(",\n", typedAnswers)}");
            

        }



    }


}
