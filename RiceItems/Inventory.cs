using System;

namespace RiceItems
{
    public class Inventory
    {
        private readonly Item[] slots;

        public Inventory(int size)
        {
            slots = new Item[size];
        }

        public int Size
        {
            get
            {
                return slots.Length;
            }
        }

        public Item GetItem(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Provided slot index must be positive", "index");
            if (index >= Size)
                throw new ArgumentOutOfRangeException("Provided slot index exceeds inventory size", "index");

            return slots[index];
        }

        public void SetItem(int index, Item itemToSet)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Provided slot index must be positive", "index");
            if (index >= Size)
                throw new ArgumentOutOfRangeException("Provided slot index exceeds inventory size", "index");

            slots[index] = itemToSet;
        }
    }
}
