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
        public Player(string name, int age, float moveSpeed, Vector2 position, Weapon weapon,int health) : base(moveSpeed, position, weapon, health)
        {
            Name = name;
            Age = age;
        }
    }

    class Unit
    {
        public float MovementSpeed { get; private set; }
        public Vector2 Position { get; private set; }
        public Weapon CurrentWeapon { get; private set; }
        public int Health { get; private set; }
        public bool IsAlive { get; private set; }
        public Unit(float movementSpeed, Vector2 position, Weapon weapon, int health)
        {
            MovementSpeed = movementSpeed;
            Position = position;
            CurrentWeapon = weapon;
            Health = health;
            IsAlive = true;
        }
        public void Move(Vector2 direction)
        {
            Position += direction * MovementSpeed;
        }

        public void Attack(Unit target = null)
        {
            if (CurrentWeapon.TryShoot())
            {
                target?.TakeDamage(CurrentWeapon.Damage);
            }
        }

        private void TakeDamage(int damage)
        {
            if (!IsAlive)
                return;
            Health -= damage;
            if (Health <= 0)
            {
                IsAlive = false;
            }
        }

        public void ChangeWeapon(Weapon weapon)
        {
            CurrentWeapon = weapon;
        }
    }

    class Weapon
    {
        public float Cooldown { get; private set; }
        public int Damage { get; private set; }
        public int Capacity { get; private set; }
        public int ClipsCount { get; private set; }
        public int CurrentBulletIndex { get; private set; }
        public bool IsReloading { get; private set; }

        public Weapon(int damage, float cooldown, int capacity)
        {
            Damage = damage;
            Cooldown = cooldown;
            Capacity = capacity;
            CurrentBulletIndex = capacity;
        }

        public void Reload()
        {
            if (ClipsCount <= 0)
            {
                return;
            }

            IsReloading = true;
            //StartReloadTimer();
        }

        public void OnReloadTimerFinished()
        {
            ClipsCount--;
            CurrentBulletIndex = Capacity;
            IsReloading = false;
        }

        public bool TryShoot()
        {
            if (CurrentBulletIndex <= 0)
            {
                Reload();
                return false;
            }

            CurrentBulletIndex--;
            return true;
        }
    }
}
