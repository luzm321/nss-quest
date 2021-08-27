using System;

namespace Quest
{
    public class Prize
    {
        private string _text { get; set; }

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                for (int i = 0; i < adventurer.Awesomeness; i++)
                {
                    Console.WriteLine($"Congrats, your prize is: {_text}!");
                }
            }
            else
            {
                Console.WriteLine("Due to your lack of Awesomeness, you don't deserve a prize! >:(");
            }
        }
    }
}