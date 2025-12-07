using System;
namespace RobotExplorer
{
    public class RobotExp
    {
        // Поля класса
        private string _mission;
        private int _protectionLvl;
        private float _powerReserve;
        private string _terrain;

        //Общее поле для всех классов
        protected int _missionDuration;

        // Конструкторы
        public RobotExp()
        {
            _mission = "Неизвестная миссия";
            _protectionLvl = 5;
            _powerReserve = 20.0f;
            _terrain = "Неизведанная территория";
            _missionDuration = 3;
        }

        public RobotExp(string mission, int protectionLvl, float powerReserve, string terrain, int missionDuration)
        {
            Mission = mission;
            ProtectionLvl = protectionLvl;
            PowerReserve = powerReserve;
            Terrain = terrain;
            MissionDuration = missionDuration;
        }

        public string Mission
        {
            get { return _mission; }
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Миссия не может не существовать!");
                    _mission = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Неккоректные данные: {ex.Message}", ex);
                }
            }
        }

        public int ProtectionLvl
        {
            get { return _protectionLvl; }
            set
            {
                if (value >= 0)
                    _protectionLvl = value;
                else
                    throw new ArgumentException("Броня не может уходить в минус!");
            }
        }

        public float PowerReserve
        {
            get { return _powerReserve; }
            set
            {
                if (value >= 0)
                    _powerReserve = value;
                else
                    throw new ArgumentException("Получается, робот не тратит, а вырабатывает энергию?!");
            }
        }

        public string Terrain
        {
            get { return _terrain; }
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Должна быть какая-нибудь местность!");
                    _terrain = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Неккоректные данные: {ex.Message}", ex);
                }
            }
        }

        public int MissionDuration
        {
            get { return _missionDuration; }
            set
            {
                if (value >= 0)
                    _missionDuration = value;
                else
                    throw new ArgumentException("Робот не может лентяйничать!");
            }
        }

        //Общий метод
        public virtual void Duration()
        {
            Console.WriteLine($"Длительность миссии составила {_missionDuration} часов.");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Миссия: {Mission}");
            Console.WriteLine($"Броня: {ProtectionLvl}");
            Console.WriteLine($"Запас хода: {PowerReserve}");
            Console.WriteLine($"Местность: {Terrain}");
            Console.WriteLine($"Длительность миссии: {MissionDuration}");
        }

        // Метод для изменения полей
        public virtual void UpdateRobot(string mission, int protectionLvl, float powerReserve, string terrain, int missionDuration)
        {
            Mission = mission;
            ProtectionLvl = protectionLvl;
            PowerReserve = powerReserve;
            Terrain = terrain;
            MissionDuration = missionDuration;
        }

        // Метод для сохранения в файл
        public virtual void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine($"Миссия: {Mission}; Броня: {ProtectionLvl}; Запас хода: {PowerReserve}; Местность: {Terrain}; Длительность миссии: {MissionDuration}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }

        // Перегрузка оператора >
        public static bool operator >(RobotExp robot1, RobotExp robot2)
        {
            return robot1.ProtectionLvl > robot2.ProtectionLvl;
        }

        // Перегрузка оператора <
        public static bool operator <(RobotExp robot1, RobotExp robot2)
        {
            return robot1.ProtectionLvl < robot2.ProtectionLvl;
        }
    }
}