using System;

namespace Fluct.Repo
{
    public class Item
        : IHaveId<int>, IDeletable
    {
        public Item(int id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public DateTime? DateOfDeletion { get; private set; }

        public int Id
        {
            get;
        }

        public bool IsDeleted { get; private set; }

        public string Name { get; set; }
        public int Value { get; set; }

        public void MarkAsDeleted()
        {
            DateOfDeletion = DateTime.Now;
            IsDeleted = true;
        }
    }
}
