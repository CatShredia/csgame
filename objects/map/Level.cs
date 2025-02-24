namespace csgame
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using static System.Console;

    public class RoomTypes
    {
        public const string Start = "/";
        public const string Boss = "B";
        public const string Enemy = "E";
        public const string Shop = "S";
        public const string Trap = "T";
    }

    class Level : Object
    {
        public Dictionary<(int, int), string> LevelStr;
        public int Length;
        public Dictionary<string, int> RandomTypes;
        private readonly Random _random = new Random();

        public Level()
        {
            LevelStr = new Dictionary<(int, int), string>();
            RandomTypes = new Dictionary<string, int>();
        }

        public void GenerateLevel(int startNumber)
        {
            if (startNumber <= 0)
            {
                throw new ArgumentException("Размер уровня должен быть больше нуля", nameof(startNumber));
            }

            Length = startNumber;
            SetRandomType();
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    LevelStr[(i, j)] = GetRandomType(i, j);
                }
            }
        }

        public string GetRandomType(int i, int j)
        {
            if (Length == 2 && i == 0 && j == 0)
            {
                return RoomTypes.Start;
            }
            else if (i == Length - 1 && j == Length - 1)
            {
                return RoomTypes.Boss;
            }
            else
            {
                var roomTypes = new List<string> { RoomTypes.Enemy, RoomTypes.Shop, RoomTypes.Trap };
                return roomTypes[_random.Next(roomTypes.Count)];
            }
        }

        public void SetRandomType()
        {
            double countOfRoom = Length * Length;
            RandomTypes[RoomTypes.Start] = 1;
            RandomTypes[RoomTypes.Boss] = 1;
            countOfRoom -= 2;

            RandomTypes[RoomTypes.Enemy] = (int)Math.Ceiling(countOfRoom * 0.5);
            RandomTypes[RoomTypes.Shop] = (int)Math.Ceiling(countOfRoom * 0.3);
            RandomTypes[RoomTypes.Trap] = (int)Math.Ceiling(countOfRoom * 0.2);
        }

        // Метод для вывода уровня на консоль
        public void WriteLevel()
        {
            WriteLine();

            for (int i = 0; i < Length; i++)
            {
                WriteLine();
                for (int j = 0; j < Length; j++)
                {
                    // Вывод значения ячейки в формате "[значение]"
                    PrintWithColor($" [{LevelStr[(i, j)]}] ", ChoiseColorForegroundType(LevelStr[(i, j)]), ConsoleColor.Black);
                }
            }
            WriteLine();
        }

        public ConsoleColor ChoiseColorForegroundType(string type)
        {
            switch (type[0])
            {
                case '/':
                    return ConsoleColor.Cyan;
                case 'B':
                    return ConsoleColor.DarkRed;
                case 'E':
                    return ConsoleColor.Red;
                case 'S':
                    return ConsoleColor.Green;
                case 'T':
                    return ConsoleColor.Blue;
                default:
                    PrintError("неправильно выбран тип", "level: printType");
                    return ConsoleColor.Black;
            }
        }
    }
}