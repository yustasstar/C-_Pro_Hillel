﻿using DesignPatternsExamples.Adapter.Interfaces;
using System;

namespace DesignPatternsExamples.Adapter.Classes
{
    public class MallardDuck : IDuck
    {
        public void Quack()
        {
            Console.WriteLine("Quack Quack Quack");
        }

        public void Fly()
        {
            Console.WriteLine("Flies 500 Metres");
        }
    }
}
