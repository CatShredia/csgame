namespace csgame
{
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;
    using static System.Console;
    class Level : Object
    {
        // Словарь для хранения строк уровня, где ключ - это координаты (i, j), а значение - строка
        public Dictionary<(int, int), string> LevelStr;
        public int Length;
        public Dictionary<string, int> RandomTypes;
        // Конструктор класса Level, инициализирующий словарь LevelStr и RandomTypes
        public Level()
        {
            LevelStr = new Dictionary<(int, int), string>();
            RandomTypes = new Dictionary<string, int>();
        }
        // Метод для генерации уровня с заданным размером
        // startNumber - размер уровня (длина и ширина)
        public void GenerateLevel(int startNumber)
        {
            Length = startNumber; // Установка длины уровня
            SetRandomType(); // Установка типов комнат для уровня
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    // Заполнение уровня случайными типами комнат
                    LevelStr[(i, j)] = GetRandomType(i, j);
                }
            }
        }
        // Метод для получения случайного типа комнаты на основе координат
        // i, j - координаты комнаты
        public string GetRandomType(int i, int j)
        {
            Random random = new Random(); // Создание нового экземпляра Random
            // Условие для первой комнаты (стартовая)
            if (Length == 2 && i == 0 && j == 0)
            {
                return "/";
            }
            // Условие для последней комнаты (комната босса)
            else if (i == Length - 1 && j == Length - 1)
            {
                return "B";
            }
            else
            {
                int choiseNumber;
                while (true)
                {
                    // Случайный выбор числа от 1 до 3
                    choiseNumber = random.Next(1, 4);
                    switch (choiseNumber)
                    {
                        case 1:
                            return "E"; // Враг
                        case 2:
                            return "S"; // Магазин
                        case 3:
                            return "T"; // Ловушка
                        default:
                            PrintError("ошибка выбора типа комнаты", "level:GetRandomTypeOfRoom"); // Обработка ошибки
                            break;
                    }
                }
            }
        }
        // Метод для установки количества каждой комнаты в зависимости от размера уровня
        public void SetRandomType()
        {
            double countOfRoom = Length * Length; // Общее количество комнат
            // Установка стартовой комнаты
            RandomTypes["/"] = 1;
            countOfRoom -= RandomTypes["/"];
            // Установка комнаты босса
            RandomTypes["B"] = 1;
            countOfRoom -= RandomTypes["B"];
            // Установка количества комнат с врагами
            RandomTypes["E"] = (int)Math.Ceiling((double)countOfRoom / 4);
            countOfRoom -= RandomTypes["E"];
            // Установка количества комнат с магазинами
            RandomTypes["S"] = (int)Math.Ceiling((double)countOfRoom / 2);
            countOfRoom -= RandomTypes["S"];
            // Установка количества ловушек
            RandomTypes["T"] = (int)Math.Ceiling((double)countOfRoom / 2);
            countOfRoom -= RandomTypes["T"];
            // Вывод типов комнат на консоль
            foreach (var item in RandomTypes)
            {
                WriteLine(item);
            }
        }
        // Метод для вывода уровня на консоль
        public void WriteLevel()
        {
            for (int i = 0; i < Length; i++)
            {
                WriteLine(); // Переход на новую строку перед выводом строки уровня
                WriteLine(); // Переход на новую строку перед выводом строки уровня
                for (int j = 0; j < Length; j++)
                {
                    // Вывод значения ячейки в формате "[значение]"
                    Write(" [" + LevelStr[(i, j)] + "] ");
                }
            }
            WriteLine(); // Переход на новую строку после завершения вывода уровня
        }
    }
}