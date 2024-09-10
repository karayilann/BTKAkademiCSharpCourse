
Book book = new Book
{
    Title = "Design Patterns",
    Author = "Erich Gamma",
    Isbn = "978-0201633610"
};

book.Show();

CareTaker careTaker = new CareTaker();
careTaker.Memento = book.CreateMemento();

Console.WriteLine("\nChanging the title...\n");

book.Title = "Design Patterns: Elements of Reusable Object-Oriented Software";
book.Show();

Console.WriteLine("\nRestoring the title...\n");
book.Restore(careTaker.Memento);
book.Show();


class Book
{
    private string _title;
    private string _author;
    private string _isbn;

    DateTime _lastEdited;
    

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            SetLastEdited();
        }
    }

    public string Author
    {
        get => _author;
        set
        {
            _author = value;
            SetLastEdited();
        }
    }

    public string Isbn
    {
        get => _isbn;
        set
        {
            _isbn = value;
            SetLastEdited();
        }
    }

    private void SetLastEdited()
    {
        _lastEdited = DateTime.Now;
    }

    public BookMemento CreateMemento()
    {
        return new BookMemento(_title, _author, _isbn, _lastEdited);
    }

    public void Restore(BookMemento memento)
    {
        _title = memento.Title;
        _author = memento.Author;
        _isbn = memento.Isbn;
        _lastEdited = memento.LastEdited;
    }

    public void Show()
    {
        Console.WriteLine($"Title: {_title}, Author: {_author}, ISBN: {_isbn}, Last Edited: {_lastEdited}");
    }

}

class BookMemento
{
    public BookMemento(string title, string author, string isbn, DateTime lastEdited)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        LastEdited = lastEdited;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public DateTime LastEdited { get; set; }
}

class CareTaker
{
    public BookMemento Memento { get; set; }
}
