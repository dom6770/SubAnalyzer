using System;
class Program {
    private static void Main(string[] args) {
        string path;

        if(args.Length > 0 && Directory.Exists(args[0])){
            path = args[0];
        } else {
            while(true) {
                Console.Write("Please enter a path: ");
                string input = Console.ReadLine();

                if(Directory.Exists(input)) {
                    path = input;
                    break;
                } else {
                    int currentLineCursor = Console.CursorTop - 1;
                    Console.Write("Invalid, please try again!");
                    Console.SetCursorPosition(0,currentLineCursor);
                    Console.Write(new string(' ',Console.BufferWidth - 1));
                    Console.SetCursorPosition(0,currentLineCursor);
                }
            }
        }
        Console.SetCursorPosition(0,Console.CursorTop);
        Console.Write(new string(' ',Console.BufferWidth - 1));
        Console.SetCursorPosition(0,Console.CursorTop);

        Console.WriteLine($"Path: {path}");

        SubAnalyzer subAnalyzer = new(path);
        subAnalyzer.Run();
    }
}