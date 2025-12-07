namespace RobotExplorer
{
    public class Archaeologist: RobotExp
    {
        // Дополнительное поле
        private float _scanningAccuracy;

        // Конструктор по умолчанию
        public Archaeologist() : base()
        {
            _scanningAccuracy = 0.0f;
        }

        // Конструктор с параметрами
        public Archaeologist(string mission, int protectionLvl, float powerReserve, string terrain, int missionDuration, float scanningAccuracy)
            : base(mission, protectionLvl, powerReserve, terrain, missionDuration)
        {
            ScanningAccuracy = scanningAccuracy;
        }

        // Свойство для дополнительного поля
        public float ScanningAccuracy
        {
            get { return _scanningAccuracy; }
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentException("Точность сканирования должна быть от 0 до 1!");
                _scanningAccuracy = value;
            }
        }

        // Переопределение методов
        public override void Duration()
        {
            Console.WriteLine($"Археолог-робот ищет артефакты");
            Console.WriteLine($"Точность сканирования: {_scanningAccuracy * 100}%");
            Console.WriteLine($"Длительность: {_missionDuration} часов");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Точность сканирования: {_scanningAccuracy * 100}%");
        }

        public override void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine($"Миссия: {Mission}; Броня: {ProtectionLvl}; Запас хода: {PowerReserve}; Местность: {Terrain}; Длительность миссии: {MissionDuration}; Точность сканирования: {ScanningAccuracy}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
}