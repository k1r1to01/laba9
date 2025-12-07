namespace RobotExplorer
{
    public class Geologist: RobotExp
    {
        // Дополнительное поле
        private int _drillingDepth;

        // Конструктор по умолчанию
        public Geologist() : base()
        {
            _drillingDepth = 100;
        }

        // Конструктор с параметрами
        public Geologist(string mission, int protectionLvl, float powerReserve, string terrain, int missionDuration, int drillingDepth)
            : base(mission, protectionLvl, powerReserve, terrain, missionDuration)
        {
            DrillingDepth = drillingDepth;
        }

        // Свойство для дополнительного поля
        public int DrillingDepth
        {
            get { return _drillingDepth; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Глубина бурения не может быть отрицательной!");
                _drillingDepth = value;
            }
        }

        // Переопределение метода
        public override void Duration()
        {
            Console.WriteLine($"Геолог-робот проводит исследование геологических пород");
            Console.WriteLine($"Глубина бурения: {_drillingDepth} метров");
            Console.WriteLine($"Длительность: {_missionDuration} часов");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Глубина бурения: {_drillingDepth} м");
        }

        public override void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine($"Миссия: {Mission}; Броня: {ProtectionLvl}; Запас хода: {PowerReserve}; Местность: {Terrain}; Длительность миссии: {MissionDuration}; Глубина бурения: {DrillingDepth}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
}
