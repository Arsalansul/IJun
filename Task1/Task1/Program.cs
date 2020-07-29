using System;
using System.Numerics;

namespace Task1
{
    class Program
    {
        class MyObject
        {
            private Vector2 _position;
            public readonly string Sprite = "";

            public Vector2 Position => _position;

            public MyObject(Vector2 position, string sprite)
            {
                _position = position;
                Sprite = sprite;
            }

            public void SetPosition(Vector2 value)
            {
                _position = value;
                if (_position.X < 0)
                    _position.X = 0;

                if (_position.Y < 0)
                    _position.Y = 0;
            }
        }
        public static void Main(string[] args)
        {
            MyObject[] objects = new MyObject[3];
            objects[0] = new MyObject(new Vector2(5, 5),  "1");
            objects[1] = new MyObject(new Vector2(10, 10),  "2");
            objects[2] = new MyObject(new Vector2(15, 15),  "3");

            Random random = new Random();

            var index = 0;
            while (true)
            {
                for (int i = 1; i < objects.Length; i++)
                {
                    var j = (index + i) % objects.Length;
                    if (objects[index]?.Position == objects[j]?.Position)
                    {
                        objects[index] = null;
                        objects[j] = null;
                    }
                }

                if (objects[index] != null)
                {
                    objects[index].SetPosition(objects[index].Position + new Vector2(random.Next(-1, 1), random.Next(-1, 1)));
                    Console.SetCursorPosition((int) objects[index].Position.X, (int) (int) objects[index].Position.Y);
                    Console.Write(objects[index].Sprite);
                }

                index = (index + 1) % objects.Length;
            }

            
        }
    }
}
