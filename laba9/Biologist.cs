namespace RobotExplorer
{
   public class Biologist: RobotExp
    {
        // Дополнительное поле
        private int _storageCapacity;

        // Конструктор по умолчанию
        public Biologist() : base()
        {
            _storageCapacity = 0;
        }

        // Конструктор с параметрами
        public Biologist(string mission, int protectionLvl, float powerReserve, string terrain, int missionDuration, int storageCapacity)
            : base(mission, protectionLvl, powerReserve, terrain, missionDuration)
        {
            StorageCapacity = storageCapacity;
        }

        // Свойство для дополнительного поля
        public int StorageCapacity
        {
            get { return _storageCapacity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Вместимость хранилища не может быть отрицательной!");
                _storageCapacity = value;
            }
        }

        // Переопределение методов
        public override void Duration()
        {
            Console.WriteLine($"Биолог-робот собирает биологические образцы");
            Console.WriteLine($"Вместимость контейнера: {_storageCapacity} образцов");
            Console.WriteLine($"Длительность: {_missionDuration} часов");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Вместимость образцов: {_storageCapacity} единиц.");
        }

        public override void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine($"Миссия: {Mission}; Броня: {ProtectionLvl}; Запас хода: {PowerReserve}; Местность: {Terrain}; Длительность миссии: {MissionDuration}; Вместимость хранилища: {StorageCapacity}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
}
