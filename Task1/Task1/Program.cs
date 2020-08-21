using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Task1
{
    class Program
    {
        private const int START_OBJECTS_AMOUNT = 3;

        class MovingObject
        {
            public readonly string Sprite = "";
            private Vector2 _position;

            public MovingObject(string sprite)
            {
                Sprite = sprite;
            }

            public Vector2 Position => _position;

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
            List<MovingObject> objects = new List<MovingObject>();
            for (int i = 0; i < START_OBJECTS_AMOUNT; i++)
            {
                var object_indicator = i + 1;
                var _object = new MovingObject(object_indicator.ToString());
                _object.SetPosition(new Vector2(object_indicator * 5, object_indicator * 5));
                objects.Add(_object);
            }

            Random random = new Random();

            while (true)
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    var collidedObjects = objects.FindAll(o => o.Position == objects[i].Position);
                    if (collidedObjects.Count > 1)
                        foreach (var collidedObject in collidedObjects)
                        {
                            objects.Remove(collidedObject);
                        }
                }

                foreach (var o in objects)
                {
                    var newPosition = o.Position + new Vector2(random.Next(-1, 1), random.Next(-1, 1));
                    o.SetPosition(newPosition);
                    Console.SetCursorPosition((int) o.Position.X, (int) o.Position.Y);
                    Console.Write(o.Sprite);
                }
            }
        }
    }
}
