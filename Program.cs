using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest by instantiating Challenge class to create new object of that class
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 21, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10; // instantiating Random class to generate random number divisible by 10
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );

            Challenge bestFruit = new Challenge(
                @"What is the best fruit in the multiverse?
    1) Mango
    2) Strawberry
    3) Jackfruit
    4) Durian
",
                1, 50
            );

            Challenge cutestAnimal = new Challenge(
                @"What is the cutest animal to ever exist?
    1) Penguin
    2) Panda
    3) Chinchilla
    4) Capybara
",
                2, 50
            );

            Challenge countryCapital = new Challenge(
             @"What is the capital city of South Korea?
    1) Busan
    2) Jeju-do
    3) Seoul
    4) Jinhae
",
             3, 20
         );

            Challenge candyColor = new Challenge(
             @"What is the rarest M&M color?
    1) Blue
    2) Red
    3) Green
    4) Brown
",
             4, 40
         );

            Challenge rainTrivia = new Challenge(
             @"What does come down but never goes up?
    1) Sun
    2) Rain
    3) Lightning
    4) Wind
",
             2, 30
         );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class, prompt user for their name, and pass value to the
            // Adventurer constructor when creating the new object:
            Console.Write(@"
                                               :
                                              ::
                                             ::
                                             ::
                                            ::
                                            ::
                              __           ::
   _..-'/-¯¯--/_          ,.--. ''.     |`\=,.. 
-:--.---''-..  /_         |\\_\..  \    `-.=._/
.-|¯         '.  \         \_ \-`/\ |    ::`
  /  @  \      \  -_   _..--|-\¯¯``'--.-/_\
  |   .-'|      \  \\-'\_/     ¯/-.|-.\_\_/
  \_./` /        \_//-''/    .-'
       |           '-/'@====/              _.--.
   __.'             /¯¯'-. \-'.          _/   /¯'
.''____|   /       |'--\__\/-._        .'    |
 \ \_. \  |       _| -/        \-.__  /     /
  \___\ '/   _.  ('-..| /       '_  ''   _.'
        /  .'     ¯¯¯¯ /        | ``'--''
       (  / ¯```¯¯¯¯¯|-|        |
        \ \_.         \ \      /  
         \___\         '.'.   /
                         /    |
                        /   .'
                       /  .' |
                     .'  / \  \
                    /___| /___'

Let's go on an adventure quest! 
Please enter your name: ");

            var adventurerName = Console.ReadLine(); // storing user's name input in string variable
            // using the object initializer to instantiate the Robe class and set its properties:
            var adventurerRobe = new Robe() { Colors = new List<string>() { "Seafoam Green", "Lilac" }, RobeLength = 21 };
            // using the object initializer to instantiate the Hat class and set its property:
            var adventurerHat = new Hat() { ShininessLevel = 21 };
            var adventurerPrize = new Prize("Rupees and Emeralds");
            Console.WriteLine();
            Adventurer theAdventurer = new Adventurer(adventurerName, adventurerRobe, adventurerHat);
            // invoking method from the Adventurer Class to display robe details prior to start of quest:
            Console.WriteLine(theAdventurer.GetDescription());
            Console.WriteLine();

            Console.WriteLine("Let the Quest begin! /(>_<)/");
            Console.WriteLine();

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                bestFruit,
                cutestAnimal,
                countryCapital,
                candyColor,
                rainTrivia
            };

            // Method that will execute the challenges for the adventurer:
            void startAdventure()
            {
                // Loop through all the challenges and subject the Adventurer to them
                // foreach (Challenge challenge in challenges)
                // {
                //     // invoke method that takes an Adventurer object and makes that Adventurer perform the challenge
                //     challenge.RunChallenge(theAdventurer);

                // }

                // randomly selects 5 challenges for the adventurer to face:
                for (int i = 0; i < 5; i++)
                {
                    int challengesCount = challenges.Count;
                    int randomChallenge = new Random().Next(challengesCount);
                    challenges[randomChallenge].RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                Console.WriteLine();
                // invoking ShowPrize() method:
                adventurerPrize.ShowPrize(theAdventurer);
                Console.WriteLine();
                Console.Write("Would you like to venture on this quest again? (Y/N): ");
                string repeatQuest = Console.ReadLine().ToLower();
                Console.WriteLine();
                // Condition that repeats the adventure or ends the program depending on user response:
                if (repeatQuest == "y")
                {
                    Console.WriteLine("Brave choice! Will it be déjà vu all over again?");
                    Console.WriteLine();
                    startAdventure();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("I bid thee adieu, see you on the next adventure! :D");
                }
            }

            startAdventure(); // invoking startAdventure() method
        }
    }
}

