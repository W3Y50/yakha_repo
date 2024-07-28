using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomQuizAPI.DataModels.Quizzes
{
    public class NewQuiz
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
    }
}
