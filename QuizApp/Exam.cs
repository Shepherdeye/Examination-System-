using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    //class ExamBuilder
    //{

    //    public static List<Question> BuildExam
    //    {

    //    }
    //}
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
           

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"\nEnter the type of Question:\n1. Multi Choice\n2. True Or False");


                int qChoice = Convert.ToInt32(Console.ReadLine());
                if(qChoice !=1 && qChoice != 2)
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
            throw new NotImplementedException();
        }


       
    }


}
