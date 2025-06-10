using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{

    //class Builder
    //{

    //    public static Question QuestionBuilder(int type)
    //    {
    //        List<string> answers = new();
    //        Console.WriteLine("Enter the Question");
    //        string? questionHead = Console.ReadLine();
    //        if (type == 4)
    //        {
    //            Console.WriteLine("Enter Your choices ");

    //            for (int i = 0; i < 4; i++)
    //            {
    //                Console.Write($"{i + 1}. ");
    //                string? answer = Console.ReadLine();
    //                if (string.IsNullOrWhiteSpace(answer)||string.IsNullOrEmpty(answer))
    //                {
    //                    Console.WriteLine("Invalid Choice, please enter a non-empty answer.");
    //                    i--;
    //                    continue;
    //                }

    //                answers.Add(answer);
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("1.True");
    //            Console.WriteLine("2.False");
    //            answers.Add("True");
    //            answers.Add("False");

    //        }
    //        Console.WriteLine("Enter right choose number");
    //        int right = Convert.ToInt32(Console.ReadLine()) - 1;

    //        if (right < 0 || right >= type) return null;

    //        Console.WriteLine("Enter The degree of Question");
    //        double degree = Convert.ToDouble(Console.ReadLine());

    //        Question question = new MultiAnswers()
    //        {
    //            QuestionHead = questionHead,
    //            Answers = answers,
    //            IndexRightAnswer = right,
    //            Degree = degree
    //        };

    //        return question;

    //    }
    //}
    abstract internal class Question
    {
        public string QuestionHead { get; protected set; } = "Unknown Question";
        public List<string> Answers { get; protected set; } = new();
        public int IndexRightAnswer { get; protected set; } = -1;
        public double Degree { get; protected set; } = -1;

        public abstract Question CreateQuestion(int type = 4);

        public override string ToString()
        {
            return $"Correct:{IndexRightAnswer} Degree:{Degree}";
        }
    }

    class MultiAnswers : Question
    {

        public override Question? CreateQuestion(int type = 4)
        {
            List<string> answers = new();
            Console.WriteLine("Enter the Question");
            string? questionHead =default;

            do
            {
                questionHead = Console.ReadLine();

                if (string.IsNullOrEmpty(questionHead) || string.IsNullOrWhiteSpace(questionHead))
                {
                    Console.WriteLine("Invalid input");

                }

            } while (string.IsNullOrEmpty(questionHead) || string.IsNullOrWhiteSpace(questionHead));


            if (type == 4)
            {
                Console.WriteLine("Enter Your choices ");

                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"{i + 1}. ");
                    string? answer = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(answer) || string.IsNullOrEmpty(answer))
                    {
                        Console.WriteLine("Invalid Choice, please enter a non-empty answer.");
                        i--;
                        continue;
                    }

                    answers.Add(answer);
                }
            }
            else
            {
                Console.WriteLine("1.True");
                Console.WriteLine("2.False");
                answers.Add("True");
                answers.Add("False");

            }
            Console.WriteLine("Enter right choose number");
            string? input = default;

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid Input ,try again");
                }


            } while (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input));
            int right = Convert.ToInt32(input) - 1;


            if (right < 0 || right >= type) return null;

            Console.WriteLine("Enter The degree of Question");
            string? degInput = default;
            

            do {
                degInput = Console.ReadLine();
                if(string.IsNullOrEmpty(degInput) || string.IsNullOrWhiteSpace(degInput))
                {
                    Console.WriteLine("Failed, please enter a valid input");
                }

            } while(string.IsNullOrEmpty(degInput) || string.IsNullOrWhiteSpace(degInput));

            //double.TryParse(degInput, out double degree);
            double degree = Convert.ToDouble(degInput);

            Question question = new MultiAnswers()
            {
                QuestionHead = questionHead,
                Answers = answers,
                IndexRightAnswer = right,
                Degree = degree
            };

            return question;

        }
    }

    class BoolQuestion : MultiAnswers
    {

        public override Question? CreateQuestion(int type = 2)
        {
            return base.CreateQuestion(2);

        }

    }

}
