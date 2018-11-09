using System;

namespace heroesFabric{
    public class Character
    {

        public Character(string name){
            Name = name;
            HealthPoint = 20;
            Strength = 7;
            Defense = 5;
            Dodge = 15;
        }

        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Dodge { get; set; }

        public int attack(int defense, int dodge)
        {
            Random random = new Random();

            if (random.Next() <= dodge / 100)
            {
                return 0;
            }
            else
            {
                return 0 - (Strength - ((Strength * defense) / 10));
            }
        }
    }
}