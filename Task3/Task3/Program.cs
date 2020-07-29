using System;
using System.Numerics;

namespace Task3
{
    class Program
    {

    }
    class Player : Unit
    {
        public readonly string Name;
        public int Age { get; private set; }

        public Player(string name, int age, float moveSpeed, Vector2 position, Weapon weapon) : base(moveSpeed, position, weapon)
        {
            Name = name;
            Age = age;
        }
    }

    class Unit
    {
        public float MovementSpeed { get; private set; }
        public Vector2 Position { get; private set; }
        private Weapon _weapon;

        public Unit(float movementSpeed, Vector2 position, Weapon weapon)
        {
            MovementSpeed = movementSpeed;
            Position = position;
            _weapon = weapon;
        }

        public void Move()
        {
            //Do move
        }

        public void Attack()
        {
            _weapon.TryShoot();
        }
    }

    class Weapon
    {
        public float Cooldown { get; private set; }
        public int Damage { get; private set; }

        public Weapon(int damage, float cooldown)
        {
            Damage = damage;
            Cooldown = cooldown;
        }

        public void TryShoot()
        {
            //attack
        }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }
}
