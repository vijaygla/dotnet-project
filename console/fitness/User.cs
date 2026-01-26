using System;

namespace FitnessApp
{
    public class User
    {
        public string Name { get; set; }
        public int Steps { get; set; }

        public User(string name, int steps)
        {
            Name = name;
            Steps = steps;
        }

        public override string ToString()
        {
            return $"{Name}: {Steps} steps";
        }
    }
}
