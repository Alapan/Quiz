using QuizGame;

Console.WriteLine("*******************************");
Console.WriteLine("********** Trivia Time ********");
Console.WriteLine("*******************************");

Console.WriteLine("Select your user type from the options below: ");
Console.WriteLine("1: Admin");
Console.WriteLine("2: Player");

int userType;

while(!int.TryParse(Console.ReadLine(), out userType) || (userType != 1 && userType != 2))
{
    Console.WriteLine("Invalid user type. Please select 1 for Admin and 2 for Player.");
}

Console.WriteLine($"The user type is {userType}");

if (userType == 1)
{
    Console.WriteLine("You have selected Admin. \n First, enter a quiz ID. This can be a new ID or an existing one, in case you want to update an existing quiz");
    int quizId = -1;
    bool isValidId = false;

    while (!isValidId || quizId < 0)
    {
        Console.WriteLine("Please enter a valid positive integer for the quiz ID.");
        isValidId = int.TryParse(Console.ReadLine(), out quizId);
        if (isValidId && quizId >=0)
        {
            break;
        }
    }

    List<Entry> questions = new List<Entry>();
    Quiz quiz = new Quiz(quizId, questions);

    int selectedChoice;
    do
    {
        Console.WriteLine($"You are setting the questions for quiz {quizId}. Select what you want to do from the list below: ");
        Console.WriteLine("1. Add a question");
        Console.WriteLine("2. View questions");
        Console.WriteLine("3. Save quiz and Exit");
        Console.WriteLine("4. Exit without saving");

        while (!int.TryParse(Console.ReadLine(), out selectedChoice) || (selectedChoice < 1 || selectedChoice > 3))
        {
            Console.WriteLine("Invalid choice. Please select a valid option from the list above.");
        }

        if (selectedChoice == 1)
        {
            Console.WriteLine("Next, set your question: ");
            string question = Console.ReadLine();

            Console.WriteLine("Enter a maximum of 4 options for this question separated by commas");
            string[] options = Console.ReadLine().Split(", ");

            Console.WriteLine("Enter the correct answer from the options entered above");
            string answer = Console.ReadLine();
            questions.Add(new Entry(question, options, answer));
        } else if (selectedChoice == 2)
        {
            quiz.displayQuiz();
        } else if (selectedChoice == 3)
        {
            quiz.saveToJson();
            Console.WriteLine("Quiz saved successfully. Exiting now.");
            break;
        }
    } while (selectedChoice != 4);
} else
{
    Console.WriteLine("Welcome to the quiz as a Player!");
}
