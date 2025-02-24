namespace csgame
{
    using System.Reflection;
    using static System.Console;

    class Level : Object
    {
        public Dictionary<(int, int), string> LevelStr;
        public int Length;
        public Level()
        {
            LevelStr = new Dictionary<(int, int), string>();
        }

        public void GenerateLevel(int startNumber)
        {
            Length = startNumber;

            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    LevelStr.Add((i, j), "/");
                }
            }
        }

        public void WriteLevel()
        {

            for (int i = 0; i < Length; i++)
            {
                WriteLine();

                for (int j = 0; j < Length; j++)
                {
                    Write(" [" + LevelStr[(i, j)] + "] ");
                }
            }

            WriteLine();
        }
    }
}