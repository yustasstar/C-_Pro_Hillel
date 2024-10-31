namespace HW_5_GarbageCollector;

public class Play : IDisposable
{
    public string? Title { get; set; }
    public string? AuthorFullName { get; set; }
    public string? Genre { get; set; }
    public int Year { get; set; }

    private bool disposed = false;

    public Play(string title, string authorFullName, string genre, int year)
    {
        Title = title;
        AuthorFullName = authorFullName;
        Genre = genre;
        Year = year;
    }

    ~Play()
    {
        Dispose(false);
        Console.WriteLine("Destructor invoked");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
        Console.WriteLine("GC.SuppressFinalize invoked");
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine("managed resources cleared");
            }
            Delete();
            Console.WriteLine("unmanaged resources cleared");
            disposed = true;
        }
    }

    public void Create(string? title, string? authorFullName, string? genre, int year)
    {
        Title = title;
        AuthorFullName = authorFullName;
        Genre = genre;
        Year = year;
        Console.WriteLine("Data created!");
    }

    public void Read()
    {
        Console.WriteLine($"Title: {Title ?? "N/A"}, Author: {AuthorFullName ?? "N/A"}, Genre: {Genre ?? "N/A"}, Year: {(Year != 0 ? Year.ToString() : "N/A")}");
    }

    public void Update(string? title = null, string? authorFullName = null, string? genre = null, int? year = null)
    {
        Title = title ?? Title;
        AuthorFullName = authorFullName ?? AuthorFullName;
        Genre = genre ?? Genre;
        Year = year ?? Year;
        Console.WriteLine("Data updated!");
    }

    public void Delete()
    {
        Title = null;
        AuthorFullName = null;
        Genre = null;
        Year = 0;
        Console.WriteLine("Data cleared!");
    }
}



