namespace SecondExample.Models
{
    class Book(string title, string author, int count)
    {
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
        public int Count { get; set; } = count;
    }
}
