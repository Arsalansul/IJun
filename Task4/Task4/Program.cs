using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Unit
    {
        public int Health { get; protected set; }
        public int Armor { get; protected set; }

        public Unit(int health, int armor)
        {
            Health = health;
            Armor = armor;
        }

        public void TakeDamage(int damage)
        {
            ProcessDamage(damage);
            if (Health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }

        protected virtual void ProcessDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }
    class Wombat : Unit
    {
        public Wombat(int health, int armor) : base(health, armor)
        {
        }
    }

    class Human : Unit
    {
        public int Agility { get; private set; }

        public Human(int health, int armor, int agility) : base(health, armor)
        {
            Agility = agility;
        }

        protected override void ProcessDamage(int damage)
        {
            Health -= damage / Agility;
        }
    }
}
