using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    internal class Quiz
    {
        public string Id { get; set; }
        public List<Entry> Questions { get; set; }

        public Quiz(string id, List<Entry> questions)
        {
            Id = id;
            Questions = questions;
        }

        public void displayQuiz()
        {
            foreach(Entry entry in Questions)
            {
                entry.displayEntry();
            }
        }
    }
}
