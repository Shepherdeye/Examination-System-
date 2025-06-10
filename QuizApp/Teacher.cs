using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Teacher
    {
        public int Id { get; protected set; }
        public string Name { get; set; }

        public List<Exam> Exams { get; protected set; } = new();

        public void AddPracticalExam()
        {
            Exams.Add(new PracticeExam());
        }

    }
}
