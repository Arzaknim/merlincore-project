using Merlin2d.Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Actors
{
    public class Backpack : IInventory
    {
        private int maxSize;
        private IItem[] items;

        public Backpack(int maxSize)
        {
            this.maxSize = maxSize;
            items = new IItem[maxSize];
        }

        public void AddItem(IItem item)
        {
            int length = this.GetItemsCount();
            if (length < this.maxSize)
            {
                items[length] = item;
            }
            else
            {
                throw new FullInventoryException("Inventory is full!!!");
            }
        }

        public int GetCapacity()
        {
            return this.maxSize;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            foreach(IItem item in items)
            {
                if(item != null)
                {
                    yield return item;
                }
                yield break;
            }
        }

        public IItem GetItem()
        {
            return items[0];
        }

        public void RemoveItem(IItem item)
        {
            RemoveItem(Array.IndexOf(items, item));
        }

        public void RemoveItem(int index)
        {
            if(index != -1)
                items[index] = null;
        }

        public void ShiftLeft()
        {
            IItem item = this.items[0];
            for (int i = 0; i < this.maxSize - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.maxSize - 1] = item;
        }

        public void ShiftRight()
        {
            IItem item = this.items[this.maxSize - 1];
            for (int i = this.maxSize - 1; i > 0; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[0] = item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int GetItemsCount()
        {
            return items.Where(item => item != null).Count();
        }

        public bool IsFull()
        {
            return this.GetItemsCount() == this.maxSize;
        }

        public void ReplaceItemAtIndex(int index, IItem item)
        {
            this.items[index] = item;
        }
    }
}
