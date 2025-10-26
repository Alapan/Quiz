namespace QuizGame
{
    public class Entry
    {
        public string Question { get; set; }
        public string[] Options { get; set; }

        private string _answer;

        public string Answer
        {
            get { return _answer; }
            set
            {
                if (Options != null &&  Options.Contains(value))
                {
                    _answer = value;
                } else
                {
                    Console.WriteLine($"Invalid option: {value}. Allowed values are {string.Join(", ", Options)}");
                }
            }
        }

        public Entry(string question, string[] options, string answer)
        {
            Question = question;
            Options = options;
            Answer = answer;
        }

        public void displayEntry()
        {
            Console.WriteLine(Question);
            Console.WriteLine('\n');
            Console.WriteLine("Options: ");
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine(Options[i]);
            }
            Console.WriteLine('\n');
            Console.WriteLine("Correct answer: " + Answer);

        }
    }
}
