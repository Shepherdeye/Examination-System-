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

       

        public static void StartNewExam(Exam exam)
        {
            exam.StartExam();
        }

    }
}
