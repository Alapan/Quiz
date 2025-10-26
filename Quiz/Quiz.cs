using System.Text.Json;


namespace QuizGame
{
    public class Quiz
    {
        public int Id { get; set; }
        public List<Entry> Questions { get; set; }

        public Quiz(int id, List<Entry> questions)
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

        public void saveToJson()
        {
            try
            {
                string directoryName = "Quizzes";
                Directory.CreateDirectory(directoryName);
                string fileName = Path.Combine(directoryName, $"{Id}.json");
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText(fileName, jsonString);
            } catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to write to this folder");
            } catch (IOException ex)
            {
                Console.WriteLine($"An error occured when writing to the file - {ex.ToString()}");
            } catch (Exception ex)
            {
                Console.WriteLine($"An error occured - {ex.ToString()}");
            }
        }
    }
}
