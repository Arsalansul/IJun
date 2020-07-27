using System;
using System.Numerics;

namespace Task1
{
    class Program
    {
        class MyObject
        {
            private Vector2 _position;
            private bool _isalave;
            private readonly string _sprite = "";
            public Vector2 Position
            {
                get => _position;
                set
                {
                    _position = value;
                    if (_position.X < 0)
                        _position.X = 0;

                    if (_position.Y < 0)
                        _position.Y = 0;
                }
            }
            public MyObject(Vector2 position, bool isalave, string sprite)
            {
                _position = position;
                _isalave = isalave;
                _sprite = sprite;
            }

            public void Death()
            {
                _isalave = false;
            }

            public void CheckCollide(MyObject obj)
            {
                if (Position == obj.Position)
                {
                    Death();
                    obj.Death();
                }
            }

            public void TryDraw()
            {
                if (_isalave)
                {
                    Console.SetCursorPosition((int)Position.X, (int)Position.Y);
                    Console.Write(_sprite);
                }
            }
        }
        public static void Main(string[] args)
        {
            var obj1 = new MyObject(new Vector2(5, 5), true, "1");
            var obj2 = new MyObject(new Vector2(10, 10), true, "2");
            var obj3 = new MyObject(new Vector2(15, 15), true, "3");

            Random random = new Random();

            while (true)
            {
                obj1.CheckCollide(obj2);
                obj1.CheckCollide(obj3);
                obj2.CheckCollide(obj3);

                obj1.Position += new Vector2(random.Next(-1,1), random.Next(-1, 1));
                obj2.Position += new Vector2(random.Next(-1,1), random.Next(-1, 1));
                obj3.Position += new Vector2(random.Next(-1,1), random.Next(-1, 1));

                obj1.TryDraw();
                obj2.TryDraw();
                obj3.TryDraw();
            }
        }
    }
}
