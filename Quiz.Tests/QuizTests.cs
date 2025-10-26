using QuizGame;

namespace Quiz.Tests
{
    public class QuizTests
    {
        [Fact]
        public void Quiz_SaveToJson_CreatesFile()
        {
            int quizId = 1;
            Entry entry1 = new Entry("What is 2+2", new string[] { "4", "5", "6", "7" }, "4");
            Entry entry2 = new Entry("What is the capital of France?", new string[] {"Berlin", "London", "Paris", "Rome" }, "Paris");
            List<Entry> entries = new List<Entry> { entry1, entry2 };
            QuizGame.Quiz quiz = new QuizGame.Quiz(quizId, entries);
            quiz.saveToJson();
            Directory.CreateDirectory("Quizzes");
            Assert.True(File.Exists(Path.Combine("Quizzes", $"{quizId}.json")));
            File.Delete(Path.Combine("Quizzes", $"{quizId}.json"));
        }
    }
}
