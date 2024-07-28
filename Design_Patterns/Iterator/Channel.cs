using System;
namespace Iterator
{
    public class Channel
    {
        public string Name { get; set; }
        public double Frequency { get; set; }

        public Channel(string name, double frequency)
        {
            Name = name;
            Frequency = frequency;
        }

        public override string ToString()
        {
            return "You are currently listening to " + Name + " (Frequency: " + Frequency + ")";
        }
    }
}

