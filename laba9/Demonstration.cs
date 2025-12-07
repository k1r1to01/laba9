namespace RobotExplorer;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Демонстрация работы роботов-исследователей\n");

        try
        {
            // Создание массива из 4 элементов базового типа
            RobotExp[] robots = new RobotExp[4];

            // Заполнение массива экземплярами производных классов
            robots[0] = new Geologist(
                mission: "Исследование поверхности Марса",
                protectionLvl: 8,
                powerReserve: 150.5f,
                terrain: "Горы",
                missionDuration: 72,
                drillingDepth: 25
            );

            robots[1] = new Biologist(
                mission: "Поиск нового коронавируса",
                protectionLvl: 6,
                powerReserve: 80.0f,
                terrain: "Ледник",
                missionDuration: 48,
                storageCapacity: 100
            );

            robots[2] = new Archaeologist(
                mission: "Раскопки древних руин Храма Тысячи ветров",
                protectionLvl: 4,
                powerReserve: 45.0f,
                terrain: "Пустыня",
                missionDuration: 120,
                scanningAccuracy: 0.98f
            );

            robots[3] = new Geologist(); // конструктор по умолчанию

            // Демонстрация работы методов
            Console.WriteLine("Информация о всех роботах:");

            for (int i = 0; i < robots.Length; i++)
            {
                Console.WriteLine($"\nРобот #{i + 1} ({robots[i].GetType().Name}):");
                robots[i].DisplayInfo();
                Console.WriteLine();
                robots[i].Duration();
                Console.WriteLine(new string('-', 40));
            }

            // Демонстрация перегрузки операторов сравнения
            Console.WriteLine("\nСравнение роботов по уровню защиты:");
            Console.WriteLine($"Робот 1 > Робот 2: {robots[0] > robots[1]}");
            Console.WriteLine($"Робот 2 < Робот 3: {robots[1] < robots[2]}");

            // Сохранение данных в файл
            Console.WriteLine("\nСохранение данных в файл...");
            string filename = @"E:\Desktop\laba9\robots.txt";

            // Очистка файла перед записью
            if (File.Exists(filename))
                File.Delete(filename);

            foreach (var robot in robots)
            {
                robot.SaveToFile(filename);
            }

            Console.WriteLine($"Данные сохранены в файл: {filename}");

            // Демонстрация работы с недопустимыми значениями (исключение)
            Console.WriteLine("\nПопытка создания робота с недопустимыми параметрами:");
            try
            {
                var invalidRobot = new Biologist(
                    mission: "", // пустое название
                    protectionLvl: 5,
                    powerReserve: 50.0f,
                    terrain: "Болото",
                    missionDuration: 24,
                    storageCapacity: -30 //отрицательное значение вместимости
                );
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}