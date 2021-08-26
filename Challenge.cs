using System;

namespace Quest
{
    // An instance of the Challenge class is an occurrence of a single challenge (object)
    public class Challenge
    {
        // These private fields hold the "state" of an individual challenge object.
        // The values stored in these fields are not accessible outside the class,
        //  but can be used by methods or properties within the class
        private string _text;
        private int _correctAnswer;
        private int _awesomenessChange;


        // A constructor for the Challenge
        // We can tell it's a constructor because it has the same name as the class 
        //   and it doesn't specify a return type
        // Note the constructor parameters and what is done with them
        public Challenge(string text, int correctAnswer, int awesomenessChange)
        {
            _text = text;
            _correctAnswer = correctAnswer;
            _awesomenessChange = awesomenessChange;
        }

        // This method will take an Adventurer object as a parameter and make that Adventurer perform the challenge
        public void RunChallenge(Adventurer adventurer)
        {
            Console.Write($"{_text}: ");
            string answer = Console.ReadLine(); // storing user answer in string data type variable

            int numAnswer;
            // Convert a string representation of number to an integer, using the int.TryParse and intParse method in C#.
            // If the string cannot be converted, the int.TryParse method returns false i.e. a Boolean value, whereas int.Parse returns
            // an exception.
            bool isNumber = int.TryParse(answer, out numAnswer);

            Console.WriteLine();
            if (isNumber && numAnswer == _correctAnswer)
            {
                Console.WriteLine("Well Done!");

                // Note how we access an Adventurer object's property
                // if adventurer answers correctly, add awesomeness points for that challenge to the current value of Awesomeness property
                adventurer.Awesomeness += _awesomenessChange;
            }
            else
            {
                Console.WriteLine("You have failed the challenge, there will be consequences.");
                // else subtract the awesomeness points for that challenge from the current value of the Awesomeness property
                adventurer.Awesomeness -= _awesomenessChange;
            }

            // Note how we call an Adventurer object's method
            Console.WriteLine(adventurer.GetAdventurerStatus());
            Console.WriteLine();
        }
    }
}
