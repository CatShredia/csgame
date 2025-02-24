namespace csgame
{
    using static System.Console;
    class Game : Object
    {
        public static Level level;
        public Game() {
            // Clear();

            PrintWithColor("Инициализация игры!", ConsoleColor.Black, ConsoleColor.DarkBlue);

            level = new Level();

            level.GenerateLevel(2);
            level.WriteLevel();
        }
    }
}