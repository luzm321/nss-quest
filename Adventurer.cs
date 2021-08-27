using System;

namespace Quest
{
    // An instance of the Adventurer class is an object that will undergo some challenges
    public class Adventurer
    {
        // This is an "immutable" property. It only has a "get". "Read-only" and no setter
        // The only place the Name can be set is in the Adventurer constructor
        // Note: the constructor is defined below.
        public string Name { get; }
        public Robe ColorfulRobe { get; }

        // This is a mutable property it has a "get" and a "set"
        //  So it can be read and changed by any code in the application
        public int Awesomeness
        { get; set; }

        // A constructor to make a new Adventurer object with a given name
        public Adventurer(string name, Robe colorfulRobe)
        {
            Name = name;
            Awesomeness = 50;
            ColorfulRobe = colorfulRobe;
        }

        // Method returns a string that contains the adventurer's name and a description of their robe:
        public string GetDescription()
        {
            // String.Join method combines many strings into one, receives 2 arguments: an array (or IEnumerable) and a separator string.
            string robeColors = String.Join(" and ", ColorfulRobe.Colors);
            string details = $"Adventurer, {Name}, is wearing a {robeColors} robe that is {ColorfulRobe.RobeLength} inches long! :)";
            return details;
        }


        // This method returns a string that describes the Adventurer's status
        // Note one way to describe what this method does is:
        //   it transforms the Awesomeness integer into a status string
        public string GetAdventurerStatus()
        {
            string status = "okay"; // initial value of status
            if (Awesomeness >= 75)
            {
                status = "great";
            }
            else if (Awesomeness < 25 && Awesomeness >= 10)
            {
                status = "not so good";
            }
            else if (Awesomeness < 10 && Awesomeness > 0)
            {
                status = "barely hanging on";
            }
            else if (Awesomeness <= 0)
            {
                status = "not gonna make it";
            }

            return $"Adventurer, {Name}, is {status}";
        }
    }
}
