namespace csgame
{
    using static System.Console;
    class Game : Object
    {
        public static Level level;
        public Game()
        {
            // Clear();

            PrintWithColor("Инициализация игры!", ConsoleColor.Black, ConsoleColor.DarkBlue);

            level = new Level();

            for (int i = 2; i < 6; i++)
            {
                level.GenerateLevel(i);
                level.WriteLevel();
            }
            // level.GenerateLevel(4);


        }
    }
}