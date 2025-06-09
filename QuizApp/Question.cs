using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{

    class Builder
    {

        public static Question QuestionBuilder(int type)
        {
            List<string> answers = new();
            Console.WriteLine("Enter the Question");
            string? questionHead = Console.ReadLine();
            if (type == 4)
            {
                Console.WriteLine("Enter Your choices ");

                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"{i + 1}. ");
                    string? answer = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(answer))
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
            int right = Convert.ToInt32(Console.ReadLine()) - 1;

            if (right < 0 || right >= type) return null;

            Console.WriteLine("Enter The degree of Question");
            double degree = Convert.ToDouble(Console.ReadLine());

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
    abstract internal class Question
    {
        public string QuestionHead { get; set; } = "Unknown Question";
        public List<string> Answers { get; set; } = new();
        public int IndexRightAnswer { get; set; } = -1;
        public double Degree { get; set; } = -1;

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
            return Builder.QuestionBuilder(type);
        }
    }

    class BoolQuestion : Question
    {

        public override Question? CreateQuestion(int type = 2)
        {
            return Builder.QuestionBuilder(type);

        }

    }

}
