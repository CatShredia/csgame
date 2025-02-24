namespace csgame
{
    using static System.Console;
    abstract class Object
    {
        public static void PrintWithColor(string text, ConsoleColor printForeground, ConsoleColor printBackground)
        {     
            WriteLine();       
            ForegroundColor = printForeground;
            BackgroundColor = printBackground;
            Write(text);

            ResetColor();
        }

        public static void PrintError(string userText, string placeInCode) {
            PrintWithColor($"Произошло исключение в {placeInCode} {userText}", ConsoleColor.Black, ConsoleColor.DarkRed);
        }
    }
}