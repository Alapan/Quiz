using QuizGame;

namespace Quiz.Tests
{
    public class EntryTests
    {
        [Fact]
        public void Entry_Checks_AnswerInOptions()
        {
            Entry entry = new Entry("What is 2+2?", new string[] { "3", "4", "5", "6" }, "4");
            entry.Answer = "4";
            Assert.Equal("4", entry.Answer);
        }

        [Fact]
        public void Entry_Checks_AnswerNotInOptions_PrintsError()
        {
            Entry entry = new Entry("What is 2+2?", new string[] { "3", "4", "5", "6" }, "7");
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            entry.Answer = "7";

            string expectedMessage = $"Invalid option: 7. Allowed values are 3, 4, 5, 6{Environment.NewLine}";
            Assert.Equal(expectedMessage, sw.ToString());
        }
    }
}
