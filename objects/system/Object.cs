namespace csgame
{
    using static System.Console;
    abstract class Object
    {
        public static void PrintWithColor(string text, ConsoleColor printForeground, ConsoleColor printBackground)
        {            
            ForegroundColor = printForeground;
            BackgroundColor = printBackground;
            WriteLine(text);

            ResetColor();
        }
    }
}