using System;

namespace RiceItems
{
    public class Item
    {
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public string Description { get; private set; }

        public Item(string name, string displayName, string description)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
        }
    }
}
