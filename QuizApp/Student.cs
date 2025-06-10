using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Dictionary<string, int> StudentScores = new Dictionary<string, int>();


        public static void StartNewExam(Exam exam)
        {
            exam.StartExam();
        }

    }
}
