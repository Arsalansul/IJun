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
            private List<Item> _items;
            public int MaxWeight { get; private set; }
            public Bag(int maxWeight)
            {
                MaxWeight = maxWeight;
            }

            public void AddItem(string name, int count)
            {
                int currentWeidth = _items.Sum(item => item.Count);
                if (currentWeidth + count > MaxWeight)
                    throw new InvalidOperationException();

                Item targetItem = _items.FirstOrDefault(item => item.Name == name);

                if (targetItem == null)
                {
                    _items.Add(new Item(count, name));
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

            public int GetItemCount(string name)
            {
                Item targetItem = _items.FirstOrDefault(item => item.Name == name);
                if (targetItem != null)
                    return targetItem.Count;
                return 0;
            }

            public void PullItem(string name)
            {
                Item targetItem = _items.FirstOrDefault(item => item.Name == name);
                targetItem?.Add(-1);
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
