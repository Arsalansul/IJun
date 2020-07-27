using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        class Bag
        {
            public List<Item> Items { get; private set; }
            public int MaxWeight { get; private set; }
            public Bag(int maxWeight)
            {
                MaxWeight = maxWeight;
            }

            public void AddItem(string name, int count)
            {
                int currentWeidth = Items.Sum(item => item.Count);
                if (currentWeidth + count > MaxWeight)
                    throw new InvalidOperationException();

                Item targetItem = Items.FirstOrDefault(item => item.Name == name);

                if (targetItem == null)
                {
                    Items.Add(new Item(count, name));
                }
                else
                {
                    targetItem.Add(count);
                }
            }

            public void IncreaseMaxWeight(int value)
            {
                MaxWeight += value;
            }
        }

        class Item
        {
            public int Count { get; private set; }
            public readonly string Name;

            public Item(int count, string name)
            {
                Count = count;
                Name = name;
            }

            public void Add(int count)
            {
                Count += count;
            }
        }
    }
}
