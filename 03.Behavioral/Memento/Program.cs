using Memento.Caretaker;
using Memento.Originator;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Memento Pattern Example (Text Editor) ===\n");

        // The client code.
        Editor editor = new Editor("State #1");
        History history = new History(editor);

        history.Backup();
        editor.Type(" + State #2");

        history.Backup();
        editor.Type(" + State #3");

        history.Backup();
        editor.Type(" + State #4");

        Console.WriteLine();
        history.ShowHistory();

        Console.WriteLine("\nClient: Now, let's rollback!\n");
        history.Undo();

        Console.WriteLine("\nClient: Once more!\n");
        history.Undo();

        Console.WriteLine("\nFinal Editor State: " + editor.GetContent());
    }
}
