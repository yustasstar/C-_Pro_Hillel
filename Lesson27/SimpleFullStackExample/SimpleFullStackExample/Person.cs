﻿namespace SimpleFullStackExample
{
    public record Person
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
