using DesignPatternsExamples.Adapter.Interfaces;
using System;

namespace DesignPatternsExamples.Adapter.Classes
{
    public class WildTurkey : ITurkey
    {
        public void Gobble()
        {
            Console.WriteLine("Gobble Gobble Gobble");
        }

        public void Fly()
        {
            Console.WriteLine("Flies 100 Metres");
        }
    }
}
