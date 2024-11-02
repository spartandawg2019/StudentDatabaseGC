using System;

public class StudentInformationApp
{
    // Instance fields to hold student data
    private string[] names = { "Daniel", "Andy", "Tom", "Min", "Adam", "Benia", "Michael", "Devipriya", "Syeda" };
    private string[] cities = { "Rome", "Traverse City", "Miami", "Troy", "Hamtramck", "Austin", "Paris", "Akron", "Birmingham" };
    private string[] foods = { "sushi", "thai", "thai", "Piergi", "pizza", "pasta", "banana pudding", "pizza", "burgers" };

    // Constructor to initialize the application
    public StudentInformationApp()
    {
        RunApplication();
    }

    // Main loop for running the application
    private void RunApplication()
    {
        Console.WriteLine("Welcome to the Student Information App!");

        while (true)
        {
            int selectedIndex = GetValidatedIndex(); // Retrieve valid student index from user
            DisplayStudentDetails(selectedIndex); // Display student info based on chosen index

            if (!AskToContinue("Would you like to learn about another student? (y/n)")) break; // Exit loop if user enters 'n'
        }

        Console.WriteLine("Thanks for using the Student Information App. Press any key to exit.");
        Console.ReadKey();
    }

    // Method to get and validate the student index from user input
    private int GetValidatedIndex()
    {
        int validIndex = -1;
        while (validIndex == -1)
        {
            Console.WriteLine($"Please enter a number between 1 and {names.Length} to select a student:");
            if (int.TryParse(Console.ReadLine(), out int userChoice) && userChoice >= 1 && userChoice <= names.Length)
            {
                validIndex = userChoice - 1; // Convert to zero-based index
            }
            else
            {
                Console.WriteLine("Invalid input. Try entering a valid number.");
            }
        }
        return validIndex;
    }

    // Method to display student information based on selected category
    private void DisplayStudentDetails(int index)
    {
        Console.WriteLine($"You selected {names[index]}.");
        string categoryChoice = GetValidatedCategory();

        switch (categoryChoice)
        {
            case "hometown":
                Console.WriteLine($"{names[index]} is from {cities[index]}.");
                break;
            case "favorite food":
                Console.WriteLine($"{names[index]}'s favorite food is {foods[index]}.");
                break;
        }
    }

    // Method to get valid category input from user
    private string GetValidatedCategory()
    {
        string category = "";
        while (category == "")
        {
            Console.WriteLine("Enter \"hometown\" or \"favorite food\":");
            string input = Console.ReadLine().ToLower().Trim();
            if (input == "hometown" || input == "favorite food" || input == "home" || input == "food")
            {
                category = input.Contains("home") ? "hometown" : "favorite food";
            }
            else
            {
                Console.WriteLine("Invalid category. Please enter \"hometown\" or \"favorite food\".");
            }
        }
        return category;
    }

    // Method to ask if the user wants to continue, returning true if yes
    private bool AskToContinue(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        string userResponse = Console.ReadLine().ToLower().Trim();
        return userResponse == "y";
    }

    // Entry point to start the application
    public static void Main(string[] args)
    {
        new StudentInformationApp(); // Instantiate the class to start the application
    }
}